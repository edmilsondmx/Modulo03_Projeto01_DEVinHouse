using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class SaleMap : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> entity)
    {
        entity.ToTable("SALES");

        entity.HasKey(s => s.Id);

        entity.Property(s => s.Id)
            .HasColumnName("ID");

        entity.Property(s => s.SaleDate)
            .HasColumnName("SALE_DATE")
            .HasColumnType("DATE");

        entity.Property(s => s.SellerId)
            .HasColumnName("SELLER_ID")
            .HasColumnType("int");

        entity.Property(s => s.BuyerId)
            .HasColumnName("BUYER_ID")
            .HasColumnType("int");
            
        entity.HasOne(s => s.UserBuyer)
            .WithMany()
            .HasForeignKey(s => s.BuyerId);

        entity.HasOne(s => s.UserSeller)
            .WithMany()
            .HasForeignKey(s => s.SellerId);
    }

}
