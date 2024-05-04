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
        builder.Property(u => u.RefreshToken).IsRequired().HasColumnType("varchar(255)");
        builder.Property(u => u.RefreshTokenExpiryTime).IsRequired().HasColumnType("datetime");

        builder.HasOne(ut => ut.User)
            .WithOne(u => u.UserToken)
            .HasForeignKey<UserToken>(ut => ut.UserId);;
    }
}