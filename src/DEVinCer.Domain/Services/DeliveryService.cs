using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCer.Domain.Exceptions;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCer.Domain.Services;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }

    public IList<DeliveryDTO> ListAll(int? addressId, int? saleId)
    {
        var query = _deliveryRepository.ListAll().AsQueryable();

        if(addressId.HasValue)
            query = query.Where(a => a.AddressId == addressId);
        
        if (saleId.HasValue)
            query = query.Where(s => s.SaleId == saleId);
        
        if (!query.ToList().Any())
            throw new IsExistsException("Registers not found!");

        return _mapper.Map<IList<DeliveryDTO>>(query).ToList();
    }
}
