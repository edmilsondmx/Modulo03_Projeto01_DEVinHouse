using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Exceptions;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;
using DEVinCer.Domain.Models;

namespace DEVinCer.Domain.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly ISaleCarRepository _saleCarRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, ISaleCarRepository saleCarRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _saleCarRepository = saleCarRepository;
    }

    public void Delete(int id)
    {
        var carDb = _carRepository.GetById(id);
        var soldCar = _saleCarRepository.ListAll().Any(s => s.CarId == id);

        if(carDb == null)
            throw new IsExistsException("Vehicle not found!");

        if(soldCar)
            throw new BadRequestException("Vehicle already sold!");
        
        _carRepository.Delete(carDb);
    }

    public CarDTO GetById(int id)
    {
        var carDb = _carRepository.GetById(id);
        if(carDb == null)
            throw new IsExistsException("Vehicle not found!");
        
        return _mapper.Map<CarDTO>(carDb);
    }

    public void Insert(CarDTO dto)
    {
        if(IsExists(dto))
            throw new NotAcceptableException("vehicle already registered!");

        if(dto.SuggestedPrice <= 0)
            throw new NotAcceptableException("The price cannot be zero");

        _carRepository.Insert(_mapper.Map<Car>(dto));
    }

    public IList<CarDTO> ListAll(string name, decimal? priceMin, decimal? priceMax, Pagination pagination)
    {
        var query = _carRepository.ListAllPg(pagination).AsQueryable();

        if(!String.IsNullOrEmpty(name))
            query = query.Where(c => c.Name.Contains(name));
        
        if (priceMin > priceMax)
            throw new NotAcceptableException("Error in parameters!");
        
        if (priceMin.HasValue)
            query = query.Where(c => c.SuggestedPrice >= priceMin);
        
        if (priceMax.HasValue)
            query = query.Where(c => c.SuggestedPrice <= priceMax);

        if (!query.ToList().Any())
            throw new IsExistsException("Registers not found!");
        
        return _mapper.Map<IList<CarDTO>>(query).ToList();        
    }

    public int GetTotal()
    {
        return _carRepository.GetTotal();
    }

    public void Update(CarDTO dto)
    {
        var carDb = _carRepository.GetById(dto.Id);
        var isNameExist = _carRepository.ListAll()
            .Any(c => c.Name == dto.Name && c.Id != dto.Id);

        if(carDb == null)
            throw new IsExistsException("Vehicle not found!");
    
        if(isNameExist)
            throw new NotAcceptableException("Name already registered!");
        
        if (dto.SuggestedPrice <= 0)
            throw new NotAcceptableException("The price cannot be zero");
        
        carDb.Update(dto);
        _carRepository.Update(carDb);
    }

    private bool IsExists(CarDTO car)
    {
        return _carRepository.ListAll()
            .Any(c => c.Name == car.Name);
    }
}
