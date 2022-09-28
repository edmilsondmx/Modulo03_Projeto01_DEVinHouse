using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
{
    public AddressRepository(DevInCarDbContext context) : base (context)
    {
    }
}
