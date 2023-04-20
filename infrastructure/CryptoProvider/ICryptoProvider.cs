namespace Infrastructure;

public interface ICryptoProvider{
    string Decrypt(string input);
    string Encrypt(string input);
}