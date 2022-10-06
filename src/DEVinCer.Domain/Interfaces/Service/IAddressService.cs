using DEVinCer.Domain.ViewModels;
using DEVinCer.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IAddressService
{
    IList<AddressViewModel> ListAll(int? cityId, int? stateId, string street, string cep);
    void Update(AddressPatchDTO addressPatchDTO, int id);
    void Delete(int id);
}
