using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IAddressRepository
{
    IQueryable<Address> ListAll();
    void Update(Address address);
    void Delete(Address adress);
}
