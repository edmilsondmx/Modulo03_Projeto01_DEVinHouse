using DEVinCer.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using DEVinCer.Infra.Data.Repositories;

namespace DEVinCer.DI.IoC;

public static class RepositoryIoC
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection builder)
    {
        return builder
            .AddScoped<IAddressRepository, AddressRepository>()
            .AddScoped<ICarRepository, CarRepository>()
            .AddScoped<IDeliveryRepository, DeliveryRepository>()
            .AddScoped<ISaleRepository, SaleRepository>()
            .AddScoped<IStateRepository, StateRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ISaleCarRepository, SaleCarRepository>();
    }
}
