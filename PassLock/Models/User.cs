using System;
using System.ComponentModel.DataAnnotations;

namespace PassLock.Models;

public class User
{
    [Required]
    public string? Login { get; set; }
    
    [Required]
    public string? Password { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public DateTime Created { get; set; }

    public User(string? login, string? password, string? email)
    {
        Login = login;
        Password = password;
        Email = email;
        Created = DateTime.Now;
    }
}