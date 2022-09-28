using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class CarRepository : BaseRepository<Car, int>, ICarRepository
{
    public CarRepository(DevInCarDbContext context) : base (context)
    {
    }
}
