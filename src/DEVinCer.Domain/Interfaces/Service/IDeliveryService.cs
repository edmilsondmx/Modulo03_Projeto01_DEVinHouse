using DEVinCar.Api.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface IDeliveryService
{
    IList<DeliveryDTO> ListAll();
    
}
