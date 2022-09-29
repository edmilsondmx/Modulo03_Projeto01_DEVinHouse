using DEVinCar.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface ICarService
{
    CarDTO GetById(int id);
    IList<CarDTO> ListAll(string name, decimal? priceMin, decimal? priceMax);
    void Insert(CarDTO dto);
    void Delete(int id);
    void Update(CarDTO dto);
}
