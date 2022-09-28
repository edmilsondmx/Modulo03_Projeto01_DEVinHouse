using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using DEVinCer.Domain.Interfaces.Repository;

namespace DEVinCer.Infra.Data.Repositories;

public class DeliveryRepository : BaseRepository<Delivery, int>, IDeliveryRepository
{
    public DeliveryRepository(DevInCarDbContext context) : base (context)
    {
    }
}
