using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IStateService
{
    IList<GetStateViewModel> ListAll(string name);
    GetStateByIdViewModel GetStateByID(int stateId);
    GetCityByIdViewModel GetCityById(int stateId, int cityId);
    IList<GetCityByIdViewModel> GetCitiesByStateId(int stateId, string name);
    void InsertCity(int stateId, CityDTO city);
    void InsertAdress(int stateId, int ciryId, AdressDTO adress);

}
