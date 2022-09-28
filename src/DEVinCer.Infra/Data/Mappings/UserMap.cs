using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCer.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("USERS");

        entity.HasKey(u => u.Id);

        entity.Property(u => u.Id)
            .HasColumnName("ID");

        entity.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired();

        entity.Property(u => u.Password)
            .HasColumnName("PASSWORD")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        entity.Property(u => u.Name)
            .HasColumnName("NAME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255)
            .IsRequired();

        entity.Property(u => u.BirthDate)
            .HasColumnName("BIRTH_DATE")
            .HasColumnType("DATE");

        entity.HasData(new[] {
                new User (1, "jose@email.com", "123456opp78", "Jose", new DateTime(2000, 12, 10)),
                new User (2, "andrea@email.com", "987dasd654321", "Andrea", new DateTime(1999, 05, 11)),
                new User (3, "adao@email.com", "2589asd", "Adao", new DateTime(2005, 09, 02)),
                new User (4, "monique@email.com", "asd45uio", "Monique", new DateTime(2001, 06, 07)),
            });
    }

}
