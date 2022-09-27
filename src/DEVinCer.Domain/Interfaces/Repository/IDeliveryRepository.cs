using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IDeliveryRepository
{
    IList<Delivery> ListAll();
}
