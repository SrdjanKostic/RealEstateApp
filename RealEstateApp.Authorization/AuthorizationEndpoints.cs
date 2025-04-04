using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using RealEstateApp.Authorization.Commands;
using Microsoft.AspNetCore.Builder;

namespace RealEstateApp.Authorization;
public static class AuthorizationEndpoints
{
    public static void MapAuthorizationEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var mediator = endpoints.ServiceProvider.GetRequiredService<IMediator>();

        endpoints.MapPost("/authorize", async (AuthorizeCommand command) =>
        {
            var result = await mediator.Send(command);
            return result ? Results.Ok() : Results.Unauthorized();
        });
    }
}
