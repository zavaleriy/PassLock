using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace PassLock.Models;

public class TablePassword : ReactiveObject
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Login { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Url { get; set; }
    public string? Note { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime LastMod { get; set; } = DateTime.Now;

    public TablePassword(string? title, string? login, string? password, string? url, string? note)
    {
        Title = title;
        Login = login;
        Password = password;
        Url = url;
        Note = note;
    }
}