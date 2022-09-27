using DEVinCar.Api.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IStateRepository
{
    IList<State> ListAll();
    State GetStateByID(int stateId);
    City GetCityById(int cityId);
    void InsertCity(City city);
    void InsertAdress(Address adress);
}
