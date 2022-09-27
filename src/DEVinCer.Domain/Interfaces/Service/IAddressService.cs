using DEVinCar.Api.DTOs;
using DEVinCar.Api.ViewModels;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IAddressService
{
    IList<AdressDTO> ListAll();
    void Update(AddressPatchDTO addressPatchDTO);
    void Delete(int id);
}