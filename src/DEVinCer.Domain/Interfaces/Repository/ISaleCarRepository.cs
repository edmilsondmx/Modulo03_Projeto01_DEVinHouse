using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface ISaleCarRepository
{
    IQueryable<SaleCar> ListAll();
}
