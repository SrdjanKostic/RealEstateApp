using MediatR;
using RealEstateApp.Authentication.Repositories;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Configuration;
using RealEstateApp.Authentication.Common;

namespace RealEstateApp.Authentication.Commands;
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    public LoginUserCommandHandler(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.User.Email);

        if (user == null || !Argon2.Verify(user.PasswordHash, request.User.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var secretKey = _configuration["JwtSecretKey"];            
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("JWT secret key is not configured.");
        }

        var token = JwtHelper.GenerateJwtToken(user, secretKey);
        return token;
    }
}
