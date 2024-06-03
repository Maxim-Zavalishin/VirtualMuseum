using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(a => a.Name).IsRequired().HasColumnType("nvarchar(200)");
        builder.Property(a => a.Text).IsRequired().HasColumnType("nvarchar(4000)");
        builder.Property(a => a.Keywords).IsRequired().HasColumnType("nvarchar(200)");

        builder.HasMany<Feedback>(a => a.Feedbacks)
            .WithOne(f => f.Article)
            .HasForeignKey(a => a.ArticleId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<AuthorArticle>(a => a.AuthorArticles)
            .WithOne(a => a.Article)
            .HasForeignKey(a => a.ArticleId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<SubTopic>(a => a.SubTopic)
            .WithMany(s => s.Articles)
            .HasPrincipalKey(s => s.Id)
            .HasForeignKey(a => a.SubTopicId);
    }
}