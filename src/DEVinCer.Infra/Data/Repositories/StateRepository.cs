using DEVinCer.Domain.Models;
using DEVinCer.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DEVinCer.Infra.Data.Repositories;

public class StateRepository : BaseRepository<State, int>, IStateRepository
{
    public StateRepository(DevInCarDbContext context) : base (context)
    {
    }
    
    public override IQueryable<State> ListAll()
    {
        return base.ListAll().Include(s => s.Cities);
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
