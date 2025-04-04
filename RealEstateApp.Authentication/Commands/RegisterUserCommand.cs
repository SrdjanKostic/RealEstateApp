using MediatR;
using static RealEstateApp.Authentication.Dtos.AuthDtos;

namespace RealEstateApp.Authentication.Commands;
public record RegisterUserCommand(RegisterUserDto User) : IRequest<RegisterUserResponseDto>;
