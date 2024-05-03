using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualMuseum.DAL.Repositories;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.DAL.DependensyInjection;

public static class DependensyInjection
{
    public static void AddDataAccessLayer(this IServiceCollection? services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MSSQL")),
            ServiceLifetime.Transient
        );
    }

    public static void InitRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<Article>, BaseRepository<Article>>();
        services.AddScoped<IBaseRepository<Author>, BaseRepository<Author>>();
        services.AddScoped<IBaseRepository<AuthorArticle>, BaseRepository<AuthorArticle>>();
        services.AddScoped<IBaseRepository<AuthorPosition>, BaseRepository<AuthorPosition>>();
        services.AddScoped<IBaseRepository<Feedback>, BaseRepository<Feedback>>();
        services.AddScoped<IBaseRepository<Position>, BaseRepository<Position>>();
        services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
        services.AddScoped<IBaseRepository<SubTopic>, BaseRepository<SubTopic>>();
        services.AddScoped<IBaseRepository<Topic>, BaseRepository<Topic>>();
        services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
    }
}