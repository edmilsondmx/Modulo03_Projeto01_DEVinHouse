using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
{
    public SaleCarRepository(DevInCarDbContext context) : base (context)
    {
        
    }
}
