using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(u => u.RefreshToken).IsRequired().HasColumnType("varchar");
        builder.Property(u => u.RefreshTokenExpiryTime).IsRequired().HasColumnType("datetime");

        builder.HasOne(u => u.User)
            .WithOne(u => u.UserToken);
    }
}