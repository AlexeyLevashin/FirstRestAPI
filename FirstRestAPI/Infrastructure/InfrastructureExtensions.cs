using FirstRestAPI.Interfaces;
using FirstRestAPI.InterfacesRepositories;
using FirstRestAPI.Models.Base;
using FirstRestAPI.Repositories;


namespace FirstRestAPI.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ApplicationContext>();
        return services;
    }
}