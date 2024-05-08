using Microsoft.EntityFrameworkCore.Storage;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.Domain.Interfaces;

public interface IUnitOfWork
{
    IBaseRepository<Article> Articles { get; set; }
    IBaseRepository<Author> Authors { get; set; }
    IBaseRepository<AuthorArticle> AuthorArticles { get; set; }
    IBaseRepository<AuthorPosition> AuthorPositions { get; set; }
    IBaseRepository<Feedback> Feedbacks { get; set; }
    IBaseRepository<Position> Position { get; set; }
    IBaseRepository<Role> Role { get; set; }
    IBaseRepository<SubTopic> SubTopics { get; set; }
    IBaseRepository<Topic> Topics { get; set; }
    IBaseRepository<User> User { get; set; }
    IBaseRepository<UserToken> UserToken { get; set; }
    
    Task<IDbContextTransaction> BeginTransactionAsync();

    Task<int> SaveChangesAsync();

    
}