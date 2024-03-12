namespace TetatetMessenger_API.Models;

public class User
{
     public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Nickname { get; set; }
    public string City { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}
