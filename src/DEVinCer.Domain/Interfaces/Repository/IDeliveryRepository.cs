using DEVinCar.Api.Models;

namespace DEVinCer.Domain.Interfaces.Repository;

public interface IDeliveryRepository
{
    IList<Delivery> ListAll();
}
