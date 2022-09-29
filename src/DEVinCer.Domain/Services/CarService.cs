using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;

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
            throw new Exception("Não existe registro!");

        if(soldCar)
            throw new Exception("Carro já vendido!");
        
        _carRepository.Delete(carDb);
    }

    public CarDTO GetById(int id)
    {
        var carDb = _carRepository.GetById(id);
        if(carDb == null)
            throw new Exception("Não existe registro!");
            //TODO: Criar exception para lista vazia!
        
        return _mapper.Map<CarDTO>(carDb);
    }

    public void Insert(CarDTO dto)
    {
        if(IsExists(dto))
            throw new Exception("Carro já cadastrado");
        if(dto.SuggestedPrice <= 0)
            throw new Exception("O preço não pode ser 0");

        _carRepository.Insert(_mapper.Map<Car>(dto));

    }

    public IList<CarDTO> ListAll(string name, decimal? priceMin, decimal? priceMax)
    {
        var query = _carRepository.ListAll().AsQueryable();

        if(!String.IsNullOrEmpty(name))
            query = query.Where(c => c.Name.Contains(name));
        
        if (priceMin > priceMax)
            throw new Exception("Erro nos parametros");
        
        if (priceMin.HasValue)
            query = query.Where(c => c.SuggestedPrice >= priceMin);
        
        if (priceMax.HasValue)
            query = query.Where(c => c.SuggestedPrice <= priceMax);

        if (!query.ToList().Any())
            throw new Exception("Não existe registro!");
        
        return _mapper.Map<IList<CarDTO>>(query).ToList();        
    }

    public void Update(CarDTO dto)
    {
        var carDb = _carRepository.GetById(dto.Id);
        var isNameExist = _carRepository.ListAll()
            .Any(c => c.Name == dto.Name && c.Id != dto.Id);

        if(carDb == null)
            throw new Exception("Não existe registro!");
    
        if(isNameExist)
            throw new Exception("Nome já cadastrado");
        
        if (dto.SuggestedPrice <= 0)
            throw new Exception("O preço não pode ser 0");
        
        carDb.Update(dto);
        _carRepository.Update(carDb);
    }

    private bool IsExists(CarDTO car)
    {
        return _carRepository.ListAll()
            .Any(c => c.Name == car.Name);
    }
}
