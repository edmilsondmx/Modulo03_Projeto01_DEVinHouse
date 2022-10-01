using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class CityRepository : BaseRepository<City, int>, ICityRepository
{
    public CityRepository(DevInCarDbContext context) : base (context)
    {
        
    }
}
