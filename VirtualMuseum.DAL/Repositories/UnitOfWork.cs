using Microsoft.EntityFrameworkCore.Storage;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context, IBaseRepository<Article> articles, IBaseRepository<Author> authors, IBaseRepository<AuthorArticle> authorArticles, IBaseRepository<AuthorPosition> authorPositions, IBaseRepository<Feedback> feedbacks, IBaseRepository<Position> position, IBaseRepository<Role> role, IBaseRepository<SubTopic> subTopics, IBaseRepository<Topic> topics, IBaseRepository<User> user, IBaseRepository<UserToken> userToken)
    {
        _context = context;
        Articles = articles;
        Authors = authors;
        AuthorArticles = authorArticles;
        AuthorPositions = authorPositions;
        Feedbacks = feedbacks;
        Position = position;
        Role = role;
        SubTopics = subTopics;
        Topics = topics;
        User = user;
        UserToken = userToken;
    }
    public IBaseRepository<Article> Articles { get; set; }
    public IBaseRepository<Author> Authors { get; set; }
    public IBaseRepository<AuthorArticle> AuthorArticles { get; set; }
    public IBaseRepository<AuthorPosition> AuthorPositions { get; set; }
    public IBaseRepository<Feedback> Feedbacks { get; set; }
    public IBaseRepository<Position> Position { get; set; }
    public IBaseRepository<Role> Role { get; set; }
    public IBaseRepository<SubTopic> SubTopics { get; set; }
    public IBaseRepository<Topic> Topics { get; set; }
    public IBaseRepository<User> User { get; set; }
    public IBaseRepository<UserToken> UserToken { get; set; }
    
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}