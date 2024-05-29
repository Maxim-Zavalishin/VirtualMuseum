using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(r => r.Name).IsRequired().HasColumnType("nvarchar(100)");

        builder.HasMany<User>(r => r.Users)
            .WithOne(u => u.Role)
            .HasPrincipalKey(r => r.Id)
            .HasForeignKey(u => u.RoleId);
        
        builder.HasData(new List<Role>()
        {
            new Role()
            {
                Id = 1,
                Name = "Пользователь"
            },
            new Role()
            {
                Id = 2,
                Name = "Администратор"
            }
        });
    }
}