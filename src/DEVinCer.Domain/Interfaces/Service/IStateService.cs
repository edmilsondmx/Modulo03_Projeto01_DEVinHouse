using DEVinCer.Domain.DTOs;
using DEVinCer.Domain.ViewModels;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IStateService
{
    IList<GetStateViewModel> ListAll(string name);
    GetStateByIdViewModel GetStateByID(int stateId);
    GetCityByIdViewModel GetCityById(int stateId, int cityId);
    IList<CityDTO> GetCitiesByStateId(int stateId, string name);
    void InsertCity(int stateId, CityDTO city);
    void InsertAdress(int stateId, int ciryId, AdressDTO adress);

}
