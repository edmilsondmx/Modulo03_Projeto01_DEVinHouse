using DEVinCer.Domain.Models;

namespace DEVinCer.Domain.ViewModels;
public class GetStateViewModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Initials { get; set; }

    public virtual List<string> Cities { get; set; } = new List<string>();

    public GetStateViewModel(State state)
    {
        Id = state.Id;
        Name = state.Name;
        Initials = state.Initials;
        foreach (var city in state.Cities)
        {
            Cities.Add(city?.Name);
        }
    }
}

