using Microsoft.Extensions.DependencyInjection;
using RealEstateApp.Users.Repositories;

namespace RealEstateApp.Users;

public static class UsersModule
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryUser, RepositoryUser>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UsersModule).Assembly));

        return services;
    }
}
