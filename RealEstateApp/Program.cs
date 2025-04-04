using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Npgsql;
using RealEstateApp.Authentication;
using RealEstateApp.Workspaces;
using RealEstateApp.Authorization;
using RealEstateApp.Authenticatio;
using RealEstateApp.Users;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// DI for Authentication module
services.AddAuthenticationModule();

// DI for Authorization module
services.AddAuthorizationModule();

// DI for Workspaces module
services.AddWorkspacesModule();

// DI for Users module
services.AddUsersModule();


// Pipeline Behavior
services.AddHttpContextAccessor();
services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoginValidationBehavior<,>));


// DI for PostgreSQL Connection
services.AddSingleton<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add JWT authentication
var configuration = builder.Configuration;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JwtSecretKey"] ?? throw new InvalidOperationException("JWT key not found"))
            )
        };
    });


var app = builder.Build();

// Configuration Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstateApp v1")); // Dodaj Swagger UI
}

// Map Authentication module endpoints
app.MapAuthenticationEndpoints();

// Map Authorization module endpoints
app.MapAuthorizationEndpoints();

// Map Workspaces module endpoints
app.MapWorkspacesEndpoints();

app.Run();
