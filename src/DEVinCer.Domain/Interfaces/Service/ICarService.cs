using DEVinCar.Domain.DTOs;

namespace DEVinCer.Domain.Interfaces.Service;

public interface ICarService
{
    CarDTO GetById(int id);
    IList<CarDTO> ListAll();
    void Insert(CarDTO dto);
    void Delete(int id);
    void Update(CarDTO dto);
}
