using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DEVinCer.Infra.Data.Repositories;

public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
{
    public SaleCarRepository(DevInCarDbContext context) : base (context)
    {
        
    }
    public override IQueryable<SaleCar> ListAll()
    {
        return base.ListAll().Include(sc => sc.Car);
    }
}
