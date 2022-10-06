using DEVinCer.Domain.Models;

namespace DEVinCer.Domain.ViewModels;
public class AddressViewModel {
    public int Id { get; set; }
    public int CityId { get; set; }
    public string Street { get; set; }
    public string Cep { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public string CityName { get; set; }
    public virtual City City { internal get; set; }

    public AddressViewModel()
    {
        
    }
}

