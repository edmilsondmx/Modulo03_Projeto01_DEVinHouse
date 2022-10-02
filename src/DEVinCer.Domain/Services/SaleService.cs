using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;
using DEVinCer.Domain.Exceptions;
using DEVinCer.Domain.Interfaces.Repository;
using DEVinCer.Domain.Interfaces.Service;

namespace DEVinCer.Domain.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly ICarRepository _carRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly ISaleCarRepository _saleCarRepository;
    private readonly IMapper _mapper;

    public SaleService(ISaleRepository saleRepository, IMapper mapper, ICarRepository carRepository, IAddressRepository addressRepository, ISaleCarRepository saleCarRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _carRepository = carRepository;
        _addressRepository = addressRepository;
        _saleCarRepository = saleCarRepository;
    }

    public SaleViewModel GetById(int id)
    {
        var sale = _saleRepository.GetById(id);
        if(sale == null)
            throw new IsExistsException("Sale not found!");

        return _mapper.Map<SaleViewModel>(sale);

    }

    public void InsertDelivery(DeliveryDTO dto, int id)
    {
        var sale = _saleRepository.GetById(id);
        var address = _addressRepository.GetById(dto.AddressId);

        if(sale == null || address == null)
            throw new IsExistsException("Registers not found!");
        
        if(dto.DeliveryForecast < DateTime.Now.Date)
            throw new BadRequestException("Delivery forecast less than current date!");
        
        if(dto.DeliveryForecast == null)
            dto.DeliveryForecast = DateTime.Now.AddDays(7);
        
        _saleRepository.InsertDelivery(_mapper.Map<Delivery>(dto));
    }

    public void InsertSale(SaleCarDTO dto, int id)
    {
        var car = _carRepository.GetById(dto.CarId);
        var sale = _saleRepository.GetById(dto.SaleId);

        if(car == null && sale == null)
            throw new IsExistsException("Registers not found!");
        
        if (dto.UnitPrice <= 0 || dto.Amount <= 0)
            throw new BadRequestException("Amount and price must be greater than zero!");

        if (dto.UnitPrice == null)
            dto.UnitPrice = car.SuggestedPrice;
        
        if (dto.Amount == null)
            dto.Amount = 1;

        _saleRepository.InsertSale(_mapper.Map<SaleCar>(dto));
    }

    public void UpdateAmount(int saleId, int carId, int amount)
    {
        var sale = _saleRepository.GetById(saleId);
        var saleCar = _saleCarRepository.GetById(carId);

        if(sale == null || saleCar == null)
            throw new IsExistsException("Registers not found!");

        if(amount <= 0)
            throw new BadRequestException("Amount must be greater than zero!");
        
        saleCar.Amount = amount;
        _saleRepository.UpdateAmount(saleCar);
    }

    public void UpdatePrice(int saleId, int carId, decimal unitPrice)
    {
        var sale = _saleRepository.GetById(saleId);
        var saleCar = _saleCarRepository.GetById(carId);

        if(sale == null || saleCar == null)
            throw new IsExistsException("Registers not found!");

        if(unitPrice <= 0)
            throw new BadRequestException("Price must be greater than zero!");
        
        saleCar.UnitPrice = unitPrice;
        _saleRepository.UpdateAmount(saleCar);
    }
}
