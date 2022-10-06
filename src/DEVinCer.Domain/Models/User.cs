using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.Enums;

namespace DEVinCer.Domain.Models;

public class User
{
    public int Id {get; internal set;}
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public Roles Role { get; set; }

    public User()
    {
        
    }
    public User(int id, string email, string password, string name, DateTime birthDate, Roles role)
    {
        Id = id;
        Email = email;
        Password = password;
        Name = name;
        BirthDate = birthDate;
        Role = role;
    }
    public void Update(UserDTO user)
    {
        Email = user.Email;
        Password = user.Password;
        Name = user.Name;
        BirthDate = user.BirthDate;
        Role = user.Role;
    }
}
