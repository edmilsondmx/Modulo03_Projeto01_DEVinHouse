using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface ICarRepository
{
    Car GetById(int id);
    IQueryable<Car> ListAll();
    void Insert(Car car);
    void Delete(Car car);
    void Update(Car car);
}
