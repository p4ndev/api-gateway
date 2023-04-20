using Auth.Domains.Contract;
using Auth.Domains.Entity;
using Auth.Providers;

namespace Auth.Repository;

public class StorageRepository : Storage, IStorageRepository{

    public User? Find(string email){
        if (Table.TryGetValue(email, out var password))
            return new User(email, password);
        return null;
    }

    public bool Find(User model){
        var usr = Find(model.Email!);
        if (usr is not null && usr.Password is not null)
            return usr.Password!.Equals(model.Password!);
        return false;
    }

    public bool Add(User model){
        if (model.Email is not null && Find(model.Email!) is null)
            return Table!.TryAdd(model.Email!, model.Password);
        return false;
    }

}
