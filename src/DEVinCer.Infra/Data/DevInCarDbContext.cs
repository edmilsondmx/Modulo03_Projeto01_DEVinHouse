using System.Runtime.Serialization;
using DEVinCar.Domain.Models;
using DEVinCer.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DEVinCar.Infra.Data;

public class DevInCarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DevInCarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleCar> SaleCars { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Address> Addresses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("DEV_IN_CAR")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AddressMap());

        modelBuilder.ApplyConfiguration(new CarMap());

        modelBuilder.ApplyConfiguration(new CityMap());

        modelBuilder.ApplyConfiguration(new DeliveryMap());

        modelBuilder.ApplyConfiguration(new SaleCarMap());

        modelBuilder.ApplyConfiguration(new SaleMap());

        modelBuilder.ApplyConfiguration(new StateMap());
    
        modelBuilder.ApplyConfiguration(new UserMap());

    }
}

