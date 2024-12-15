using FirstRestAPI.Interfaces;
using FirstRestAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FirstRestAPI.Application.Extensions;




public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<IPostServices, PostServices>();
        return services;
    }
}
