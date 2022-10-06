using DEVinCer.Domain.Models;
using DEVinCer.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DEVinCer.Infra.Data.Repositories;

public class DeliveryRepository : BaseRepository<Delivery, int>, IDeliveryRepository
{
    public DeliveryRepository(DevInCarDbContext context) : base (context)
    {
    }
    public override IQueryable<Delivery> ListAll()
    {
        return _context.Deliveries
            .Include(d => d.Address)
            .Include(d => d.Sale);
    }
}
