using DEVinCar.Api.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IAddressRepository
{
    IList<Address> ListAll();
    void Update(Address address);
    void Delete(Address adress);
}
