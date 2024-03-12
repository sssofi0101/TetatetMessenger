using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace TetatetMessenger_API.Models;

public class User
{
     public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public string City { get; set; }
    public string Password { get; set; }

    public User(string nickname, string password)
    {
        Nickname = nickname;
        Password = password;
    }
    public User(string nickname, string password,string name, string surname,string city) : this(nickname, password)
    {
        Name = name;
        Surname = surname;
        City = city;
    }
    public User() { }
}
