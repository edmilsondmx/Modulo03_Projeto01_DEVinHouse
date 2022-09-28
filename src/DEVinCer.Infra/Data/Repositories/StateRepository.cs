using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class StateRepository : BaseRepository<State, int>, IStateRepository
{
    public StateRepository(DevInCarDbContext context) : base (context)
    {
    }

    public City GetCityById(int cityId)
    {
        return _context.Cities.Find(cityId);
    }

    public void InsertAdress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();
    }

    public void InsertCity(City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();
    }
}
