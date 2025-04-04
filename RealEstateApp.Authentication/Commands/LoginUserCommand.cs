using MediatR;
using RealEstateApp.Authentication.Common;
using static RealEstateApp.Authentication.Dtos.AuthDtos;

namespace RealEstateApp.Authentication.Commands;
public record LoginUserCommand(LoginUserDto User) : IRequest<string>, IRequireNoAuthentication;
