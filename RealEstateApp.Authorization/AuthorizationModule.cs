using Microsoft.Extensions.DependencyInjection;
using RealEstateApp.Authorization.Repositories;

namespace RealEstateApp.Authorization;
public static class AuthorizationModule
{
    public static IServiceCollection AddAuthorizationModule(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthorizationModule).Assembly));

        services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

        return services;
    }
}
