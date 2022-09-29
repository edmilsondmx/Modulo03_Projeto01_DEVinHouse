using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IDeliveryRepository
{
    IQueryable<Delivery> ListAll();
}
