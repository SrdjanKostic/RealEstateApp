using System.Data;
using Dapper;
using Isopoh.Cryptography.Argon2;
using MediatR;
using RealEstateApp.Authentication.Entities;
using static RealEstateApp.Authentication.Dtos.AuthDtos;

namespace RealEstateApp.Authentication.Commands;
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponseDto>
{
    private readonly IDbConnection _db;

    public RegisterUserHandler(IDbConnection db)
    {
        _db = db;
    }
    public async Task<RegisterUserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.User.Email) || !request.User.Email.Contains('@'))
        {
            return new RegisterUserResponseDto(false, "Invalid email format.");
        }

        var existingUser = await _db.QueryFirstOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Email = @Email",
             new { request.User.Email });

        if (existingUser != null)
        {
            return new RegisterUserResponseDto(false, "User already exists.");
        }

        string passwordHash = Argon2.Hash(request.User.Password);

        var query = "INSERT INTO Users (Email, PasswordHash) VALUES (@Email, @PasswordHash)";
        var result = await _db.ExecuteAsync(query, new { request.User.Email, PasswordHash = passwordHash });

        if (result > 0)
        {
            return new RegisterUserResponseDto(true, "Registration successful.");
        }

        return new RegisterUserResponseDto(false, "An error occurred during registration.");
    }
}
