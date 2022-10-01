using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class SaleRepository : BaseRepository<Sale, int>, ISaleRepository
{
    public SaleRepository(DevInCarDbContext context) : base (context)
    {
    }

    public void InsertDelivery(Delivery delivery)
    {
        _context.Deliveries.Add(delivery);
        _context.SaveChanges();
    }

    public void InsertSale(SaleCar saleCar)
    {
        _context.SaleCars.Add(saleCar);
        _context.SaveChanges();
    }

    public void UpdateAmount(SaleCar saleCar)
    {
        _context.SaleCars.Update(saleCar);
        _context.SaveChanges();
    }

    public void UpdatePrice(SaleCar saleCar)
    {
        _context.SaleCars.Update(saleCar);
        _context.SaveChanges();
    }
}
