using DEVinCer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> entity)
    {
        entity.ToTable("ADDRESS");

        entity.HasKey(a => a.Id);

        entity.Property(a => a.Id)
            .HasColumnName("ID");

        entity.Property(a => a.CityId)
            .HasColumnName("CITY")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(a => a.Street)
            .HasColumnName("STREET")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(a => a.Cep)
            .HasColumnName("CEP")
            .HasColumnType("VARCHAR")
            .HasMaxLength(8)
            .IsRequired();

        entity.Property(a => a.Number)
            .HasColumnName("NUMBER")
            .HasColumnType("int")
            .IsRequired();

        entity.Property(a => a.Complement)
            .HasColumnName("COMPLEMENT")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        entity.HasOne<City>(a => a.City)
        .WithMany(c => c.Addresses)
        .HasForeignKey(a => a.CityId)
        .IsRequired();
    }
}
