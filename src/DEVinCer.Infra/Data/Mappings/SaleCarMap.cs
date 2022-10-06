using DEVinCer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class SaleCarMap : IEntityTypeConfiguration<SaleCar>
{
    public void Configure(EntityTypeBuilder<SaleCar> entity)
    {
        entity.ToTable("SALECAR");

        entity.HasKey(sc => sc.Id);

        entity.Property(sc => sc.Id)
            .HasColumnName("ID");

        entity.Property(sc => sc.SaleId)
            .HasColumnName("SALE_ID")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(sc => sc.CarId)
            .HasColumnName("CAR_ID")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(sc => sc.UnitPrice)
            .HasColumnName("UNIT_PRICE")
            .HasPrecision(18, 2);

        entity.Property(sc => sc.Amount)
            .HasColumnName("AMOUNT")
            .HasColumnType("int");

        entity.HasOne<Car>(sc => sc.Car)
            .WithMany(c => c.Sales)
            .HasForeignKey(sc => sc.Id);                

        entity.HasOne<Sale>(sc => sc.Sale)
            .WithMany(s => s.Cars)
            .HasForeignKey(sc => sc.Id);    
    }

}
