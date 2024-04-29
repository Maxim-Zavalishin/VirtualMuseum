using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(a => a.Firstname).IsRequired().HasColumnType("varchar(100)");
        builder.Property(a => a.Secondname).HasColumnType("varchar(100)");
        builder.Property(a => a.Lastname).IsRequired().HasColumnType("varchar(200)");

        builder.HasMany<AuthorArticle>(a => a.AuthorArticles)
            .WithOne(a => a.Author)
            .HasPrincipalKey(a => a.Id)
            .HasForeignKey(a => a.AuthorId);

        builder.HasMany<AuthorPosition>(a => a.AuthorPositions)
            .WithOne(p => p.Author)
            .HasPrincipalKey(a => a.Id)
            .HasForeignKey(p => p.AuthorId);
    }
}