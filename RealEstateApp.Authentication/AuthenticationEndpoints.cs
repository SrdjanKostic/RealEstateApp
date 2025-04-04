using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RealEstateApp.Authentication.Commands;
using static RealEstateApp.Authentication.Dtos.AuthDtos;

namespace RealEstateApp.Authenticatio;
public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth")
                    .WithTags("Authentication");

        // POST Endpoint RegisterUser
        group.MapPost("/register", async (IMediator mediator, RegisterUserDto dto) =>
        {
            var result = await mediator.Send(new RegisterUserCommand(dto));

            // Provera da li je registracija bila uspešna
            return result.Success ? Results.Ok("User registered successfully") : Results.BadRequest(result.Message);
        });


        // POST Endpoint LogInUser
        group.MapPost("/login", async (IMediator mediator, LoginUserDto dto) =>
        {
            var token = await mediator.Send(new LoginUserCommand(dto));

            if (token == null)
            {
                return Results.Json(new { Message = "Invalid credentials" }, statusCode: 401);
            }

            return Results.Ok(new { Token = token });
        });
    }
}
