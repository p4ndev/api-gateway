using System.Security.Cryptography;
using System.Text;

namespace Infrastructure;

public class CryptoProvider : ICryptoProvider{

    private readonly string _key;
    private readonly Rfc2898DeriveBytes _pdb;

    private readonly byte[] _sixteen;
    private readonly byte[] _thirtyTwo;

    public CryptoProvider(string key){

        _key = key;
        _pdb = new Rfc2898DeriveBytes(_key, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });

        _thirtyTwo = _pdb.GetBytes(32);
        _sixteen = _pdb.GetBytes(16);

    }

    public string Encrypt(string input){

        byte[] clearBytes = Encoding.Unicode.GetBytes(input);

        using (Aes encryptor = Aes.Create()){

            encryptor.Key = _thirtyTwo;
            encryptor.IV = _sixteen;

            using (MemoryStream ms = new MemoryStream()){

                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)){
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                input = Convert.ToBase64String(ms.ToArray());

            }

        }

        return input;

    }

    public string Decrypt(string input){

        input = input.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(input);

        using (Aes encryptor = Aes.Create()){

            encryptor.Key = _thirtyTwo;
            encryptor.IV = _sixteen;

            using (MemoryStream ms = new MemoryStream()){

                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)){
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                input = Encoding.Unicode.GetString(ms.ToArray());

            }

        }

        return input;

    }

}