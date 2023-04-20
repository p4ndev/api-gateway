using System.ComponentModel.DataAnnotations;

namespace Auth.Domains.Entity;

public class User {

    public User() { }

    public User(string email){
        Email       = email;
    }

    public User(string email, string password){
        Email       = email;
        Password    = password;
    }

    [Required]
    [EmailAddress]
    public string? Email        { get; set; }

    [MinLength(5)]
    public string? Password     { get; set; }

}