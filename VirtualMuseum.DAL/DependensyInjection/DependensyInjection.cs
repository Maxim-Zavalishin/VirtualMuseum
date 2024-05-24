using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualMuseum.DAL.Repositories;
using VirtualMuseum.Domain.Entity;
using VirtualMuseum.Domain.Interfaces;

namespace VirtualMuseum.DAL.DependensyInjection;

public static class DependensyInjection
{
    /// <summary>
    /// Подключение базы данных.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddDataAccessLayer(this IServiceCollection? services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MSSQL")),
            ServiceLifetime.Transient
        );

        services.InitRepositories();
    }

    /// <summary>
    /// Регистрация репозиториев.
    /// </summary>
    /// <param name="services"></param>
    public static void InitRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
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
        services.AddScoped<IBaseRepository<UserToken>, BaseRepository<UserToken>>();
    }
}