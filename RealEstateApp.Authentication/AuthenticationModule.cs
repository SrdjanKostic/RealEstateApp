using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using RealEstateApp.Authentication.Repositories;
using RealEstateApp.Authentication.Commands;
using static RealEstateApp.Authentication.Dtos.AuthDtos;

namespace RealEstateApp.Authentication;
public static class AuthenticationModule
{
    public static IServiceCollection AddAuthenticationModule(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddTransient<IAuthenticationService, AuthenticationService>();

        services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponseDto>, RegisterUserHandler>();


        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
