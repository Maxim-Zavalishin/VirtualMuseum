using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(u => u.Firstname).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(u => u.Secondname).HasColumnType("nvarchar(100)");
        builder.Property(u => u.Lastname).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(u => u.Email).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(u => u.Login).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(u => u.Password).IsRequired().HasColumnType("nvarchar(200)");
        builder.Property(u => u.Mailing).IsRequired();

        builder.HasMany<Feedback>(u => u.Feedbacks)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasPrincipalKey(r => r.Id)
            .HasForeignKey(u => u.RoleId);

        builder.HasOne<UserToken>(u => u.UserToken)
            .WithOne(ut => ut.User)
            .HasForeignKey<UserToken>(ut => ut.UserId);
    }
}