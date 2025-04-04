namespace RealEstateApp.Authentication.Dtos;
public class AuthDtos
{
    public record RegisterUserDto(string Email, string Password);
    public record LoginUserDto(string Email, string Password);
    public record RegisterUserResponseDto(bool Success, string Message);
    public record LoginUserResponseDto(string Token);
}
