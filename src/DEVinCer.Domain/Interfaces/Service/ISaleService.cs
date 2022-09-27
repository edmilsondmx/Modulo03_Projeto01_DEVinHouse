using DEVinCar.Api.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface ISaleService
{
    SaleCarDTO GetById(int id);
    void InsertSale(SaleCarDTO dto);
    void InsertDelivery(DeliveryDTO dto);
    void UpdateAmount(int amount);
    void UpdatePrice(decimal price);
    
}
