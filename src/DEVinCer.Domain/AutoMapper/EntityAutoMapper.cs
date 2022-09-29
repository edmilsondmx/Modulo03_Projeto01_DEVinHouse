using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCer.Domain.AutoMapper;

public class EntityAutoMapper : Profile
{
    public EntityAutoMapper()
    {
        CreateMap<AdressDTO, Address>()
            .ReverseMap();

        CreateMap<CityDTO, City>()
            .ReverseMap();
        
        CreateMap<CarDTO, Car>()
            .ReverseMap();

        CreateMap<DeliveryDTO, Delivery>()
            .ReverseMap();

        CreateMap<SaleDTO, Sale>()
            .ReverseMap();

        CreateMap<BuyDTO, Sale>()
            .ReverseMap();

        CreateMap<SaleCarDTO, SaleCar>()
            .ReverseMap();

        CreateMap<StateDTO, State>()
            .ReverseMap();

        CreateMap<UserDTO, User>()
            .ReverseMap();


    }
}
