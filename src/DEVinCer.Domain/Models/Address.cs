using DEVinCer.Domain.DTOs;

namespace DEVinCer.Domain.Models;

public class Address
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public string Street { get; set; }
    public string Cep { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }

    public virtual City City { get; set; }

    public virtual List<Delivery> Deliveries {get; set;}

    public Address()
    {
    }

    public void Update(AddressPatchDTO dto)
    {
        Street = dto.Street;
        Cep = dto.Cep;
        Number = dto.Number;
        Complement = dto.Complement;
    }
}
