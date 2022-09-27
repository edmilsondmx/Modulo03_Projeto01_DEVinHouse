using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IStateService
{
    IList<GetStateViewModel> ListAll();
    GetStateByIdViewModel GetStateByID(int stateId);
    GetCityByIdViewModel GetCityById(int cityId);
    void InsertCity(int stateId, CityDTO city);
    void InsertAdress(int stateId, int ciryId, AdressDTO adress);

}
