using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");

        builder.HasMany<AuthorPosition>(p => p.AuthorPositions)
            .WithOne(a => a.Position)
            .HasPrincipalKey(p => p.Id)
            .HasForeignKey(a => a.PositionId);
    }
}