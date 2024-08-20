using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class AuthorArticleConfiguration : IEntityTypeConfiguration<AuthorArticle>
{
    public void Configure(EntityTypeBuilder<AuthorArticle> builder)
    {
        //Тестовая запись
        builder.HasData(new List<AuthorArticle>()
        {
            new AuthorArticle()
            {
                Id = 1,
                AuthorId = 1,
                ArticleId = 1
            }
        });
        
    }
}