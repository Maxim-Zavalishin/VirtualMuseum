using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(f => f.Text).IsRequired().HasColumnType("varchar(300)");
        builder.Property(f => f.CreatedAt).IsRequired().HasColumnType("datetime");

        builder.HasOne<Article>(f => f.Article)
            .WithMany(a => a.Feedbacks)
            .HasPrincipalKey(a => a.Id)
            .HasForeignKey(f => f.ArticleId);

        builder.HasOne<User>(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasPrincipalKey(u => u.Id)
            .HasForeignKey(a => a.UserId);
    }
}