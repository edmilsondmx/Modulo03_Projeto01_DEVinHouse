using DEVinCer.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface ICarRepository : IBaseRepository<Car, int>
{
    IQueryable<Car> ListAllPg(Pagination pagination);
}
