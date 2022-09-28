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
        throw new NotImplementedException();
    }

    public void InsertAdress(Address adress)
    {
        throw new NotImplementedException();
    }

    public void InsertCity(City city)
    {
        throw new NotImplementedException();
    }
}
