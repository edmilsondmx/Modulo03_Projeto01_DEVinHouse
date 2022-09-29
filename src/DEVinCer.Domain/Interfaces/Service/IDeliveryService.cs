using DEVinCar.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IDeliveryService
{
    IList<DeliveryDTO> ListAll(int? addressId, int? saleId);
    
}
