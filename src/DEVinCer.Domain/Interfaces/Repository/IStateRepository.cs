using DEVinCer.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IStateRepository : IBaseRepository<State, int>
{
    City GetCityById(int cityId);
    void InsertCity(City city);
    void InsertAdress(Address adress);
}
