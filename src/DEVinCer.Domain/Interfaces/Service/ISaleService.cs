using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.ViewModels;

namespace DEVinCer.Domain.Interfaces.Service;

public interface ISaleService
{
    SaleViewModel GetById(int id);
    void InsertSale(SaleCarDTO dto, int id);
    void InsertDelivery(DeliveryDTO dto, int id);
    void UpdateAmount(int saleId, int cardId, int amount);
    void UpdatePrice(int saleId, int carId, decimal unitPrice);
    
}
