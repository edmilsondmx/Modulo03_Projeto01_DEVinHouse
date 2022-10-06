using DEVinCer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class CarMap : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> entity)
    {
        entity.ToTable("CARS");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
            .HasColumnName("ID");

        entity.Property(c => c.Name)
            .HasColumnName("NAME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

        entity
            .Property(c => c.SuggestedPrice)
            .HasColumnName("SUGGESTED_PRICE")
            .HasPrecision(18,2);

        entity
            .HasData(new[] {
                new Car (1, "Camaro Chevrolet", 60000M),
                new Car (2, "Maverick Ford", 20000M),
                new Car (3, "Astra Chevrolet", 30000M),
                new Car (4, "Hilux Toyota", 20000M),
                new Car (5, "Bravo Fiat", 20000M),
                new Car (6, "BR800 Gurgel", 10000M),
                new Car (7, "147 Fiat", 50000M),
                new Car (8, "Del Rey Ford", 10000M),
                new Car (9, "Mustang Ford", 70000M),
                new Car (10, "Belina Ford", 20000M)
            });
    }

}
