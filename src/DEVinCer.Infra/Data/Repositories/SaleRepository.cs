using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class SaleRepository : BaseRepository<SaleCar, int>, ISaleRepository
{
    public SaleRepository(DevInCarDbContext context) : base (context)
    {
    }

    public void InsertDelivery(Delivery delivery)
    {
        throw new NotImplementedException();
    }

    public void InsertSale(SaleCar saleCar)
    {
        throw new NotImplementedException();
    }

    public void UpdateAmount(SaleCar saleCar)
    {
        throw new NotImplementedException();
    }

    public void UpdatePrice(SaleCar saleCar)
    {
        throw new NotImplementedException();
    }
}
