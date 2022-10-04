namespace DEVinCer.Domain.ViewModels;

public class UserViewModel
{
    public int Id {get; internal set;}
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Role { get; set; }
}
