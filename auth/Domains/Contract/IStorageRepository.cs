using Auth.Domains.Entity;

namespace Auth.Domains.Contract;

public interface IStorageRepository{    
    User?   Find(string email);
    bool    Add(User model);
    bool    Find(User model);
}