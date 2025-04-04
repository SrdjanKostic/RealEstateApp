using MediatR;
using RealEstateApp.Authorization.Repositories;

namespace RealEstateApp.Authorization.Commands;
public class AuthorizeCommandHandler : IRequestHandler<AuthorizeCommand, bool>
{
    private readonly IAuthorizationRepository _repository;

    public AuthorizeCommandHandler(IAuthorizationRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CheckPermissionAsync(request.UserId, request.Permission);
    }
}
