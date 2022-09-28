using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {
        entity.ToTable("ADDRESS");

        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id)
            .HasColumnName("ID")
            .HasColumnType("uniqueidentifier");

        entity.Property(d => d.CityId)
            .HasColumnName("CITY_ID")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(d => d.Street)
            .HasColumnName("STREET")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(d => d.Cep)
            .HasColumnName("CEP")
            .HasColumnType("VARCHAR")
            .HasMaxLength(8)
            .IsRequired();

        entity.Property(d => d.Number)
            .HasColumnName("NUMBER")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(d => d.Complement)
            .HasColumnName("COMPLEMENT")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        entity.HasOne<City>(a => a.City)
        .WithMany(c => c.Addresses)
        .HasForeignKey(a => a.CityId)
        .IsRequired();
    }
}
