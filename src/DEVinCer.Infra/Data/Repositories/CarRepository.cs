using DEVinCer.Domain.Models;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class CarRepository : BaseRepository<Car, int>, ICarRepository
{
    public CarRepository(DevInCarDbContext context) : base (context)
    {
    }
    public IQueryable<Car> ListAllPg(Pagination pagination)
    {
        return _context.Cars.Take(pagination.Take).Skip(pagination.Skip);
    }
}
