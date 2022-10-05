using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DEVinCer.Infra.Data.Repositories;

public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
{
    public AddressRepository(DevInCarDbContext context) : base (context)
    {
    }
    public override IQueryable<Address> ListAll()
    {
        return base.ListAll().Include(a => a.City);
    }
}
