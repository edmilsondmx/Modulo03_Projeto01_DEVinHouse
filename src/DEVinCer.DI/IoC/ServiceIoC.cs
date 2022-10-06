using DEVinCer.Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using DEVinCer.Domain.Services;
using DEVinCer.Infra.Data;

namespace DEVinCer.DI.IoC;

public static class ServiceIoC
{
    public static IServiceCollection RegisterServices(this IServiceCollection builder)
    {
        return builder
            .AddDbContext<DevInCarDbContext>()
            .AddScoped<IAddressService, AddressService>()
            .AddScoped<ICarService, CarService>()
            .AddScoped<IDeliveryService, DeliveryService>()
            .AddScoped<ISaleService, SaleService>()
            .AddScoped<IStateService, StateService>()
            .AddScoped<IUserService, UserService>();
    }
}
