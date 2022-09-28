using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class CityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> entity)
    {
        entity.ToTable("CITIES");

        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
            .HasColumnName("ID")
            .HasColumnType("uniqueidentifier");

        entity.Property(c => c.Name)
            .HasColumnName("NAME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(c => c.StateId)
            .HasColumnName("STATE_ID")
            .HasColumnType("int")
            .IsRequired();

        entity.HasOne<State>(c => c.State)
            .WithMany(s => s.Cities)
            .HasForeignKey(c => c.StateId)
            .IsRequired();
    }

}
