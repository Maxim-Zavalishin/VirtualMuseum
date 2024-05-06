using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualMuseum.Application.AutoMapper.ArticleMappers;
using VirtualMuseum.Application.AutoMapper.UserMapper;
using VirtualMuseum.Application.Services;
using VirtualMuseum.Domain.Interfaces.Services;

namespace VirtualMuseum.Application.DependensyInjection;

public static class DependensyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappers();
        services.InitServices();
    }
    private static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapper));
        services.AddAutoMapper(typeof(UserRegisterMapper));
        services.AddAutoMapper(typeof(GetArticleMapper));
    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IArticleService, ArticleServices>();
    }
}