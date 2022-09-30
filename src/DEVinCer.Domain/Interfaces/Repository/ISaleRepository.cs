using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface ISaleRepository : IBaseRepository<Sale, int>
{
    void InsertSale(SaleCar sale);
    void InsertDelivery(Delivery delivery);
    void UpdateAmount(SaleCar saleCar);
    void UpdatePrice(SaleCar saleCar);
}
