using DEVinCer.Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using DEVinCer.Domain.Services;

namespace DEVinCer.DI.IoC;

public static class ServiceIoC
{
    public static IServiceCollection RegisterServices(this IServiceCollection builder)
    {
        return builder
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<ICarService, CarService>()
            .AddScoped<IDeliveryService, DeliveryService>()
            .AddScoped<ISaleService, SaleService>()
            .AddScoped<IStateService, StateService>()
            .AddScoped<IUserService, UserService>();
    }
}
