using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCer.Domain.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    private readonly IDeliveryRepository _deliveryRepository;

    public AddressService(IAddressRepository addressRepository, IMapper mapper, IDeliveryRepository deliveryRepository)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
        _deliveryRepository = deliveryRepository;
    }

    public void Delete(int id)
    {
        var addressDb = _addressRepository.ListAll().FirstOrDefault(a => a.Id == id);

        var relation = _deliveryRepository.ListAll().FirstOrDefault(d => d.AddressId == id);

        if(addressDb == null)
            throw new Exception("Não existe registro!");

        if(relation != null)
            throw new Exception("O endereço está relacionado a uma entrega");

        _addressRepository.Delete(addressDb);
    }

    public IList<AddressViewModel> ListAll(int? cityId, int? stateId, string street, string cep)
    {
        var query = _addressRepository.ListAll().AsQueryable();

        if (cityId.HasValue)
            query = query.Where(a => a.CityId == cityId);
        
        if (stateId.HasValue)
            query = query.Where(a => a.City.StateId == stateId);

        if (!string.IsNullOrEmpty(street))
        {
            street = street.ToUpper();
            query = query.Where(a => a.Street.Contains(street));
        }
         
        if (!string.IsNullOrEmpty(cep))
            query = query.Where(a => a.Cep == cep);

        if (!query.ToList().Any())
            throw new Exception("Não existe registro!");

        return _mapper.Map<IList<AddressViewModel>>(query).ToList();
    }

    public void Update(AddressPatchDTO addressPatchDTO, int id)
    {
        var addressDb = _addressRepository
            .ListAll().FirstOrDefault(a => a.Id == id);

        if (addressDb == null)
            throw new Exception("Não existe registro!");
        
        if(addressPatchDTO.Number <= 0)
            throw new Exception("adicione um numero valido");

        if (!addressPatchDTO.Cep.All(char.IsDigit))
                throw new Exception("Every characters in cep must be numeric.");

        addressDb.Update(addressPatchDTO);
        _addressRepository.Update(addressDb);        
    }
}
