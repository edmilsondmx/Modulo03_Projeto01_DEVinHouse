using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class DeliveryMap : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> entity)
    {
        entity.ToTable("DELIVERIES");

        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id)
            .HasColumnName("ID");

        entity.Property(d => d.AddressId)
            .HasColumnName("ADDRESS_ID")
            .HasColumnType("int");

        entity.Property(d => d.SaleId)
            .HasColumnName("SALE_ID")
            .HasColumnType("int");

        entity.Property(d => d.DeliveryForecast)
            .HasColumnName("DELIVERY_FORECAST")
            .HasColumnType("DATE");
            

        entity.HasOne<Address>(d => d.Address)
            .WithMany(a => a.Deliveries)
            .HasForeignKey(d => d.AddressId);
        
        entity.HasOne<Sale>(d => d.Sale)
            .WithMany(s => s.Deliveries)
            .HasForeignKey(d => d.SaleId);
    }
}
