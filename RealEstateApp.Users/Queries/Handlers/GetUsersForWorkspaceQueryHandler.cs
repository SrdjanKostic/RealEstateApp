using MediatR;
using RealEstateApp.Contracts.Dtos;
using RealEstateApp.Contracts.Events;
using RealEstateApp.Users.Repositories;

namespace RealEstateApp.Users.Queries.Handlers;
public class GetUsersForWorkspaceQueryHandler : IRequestHandler<GetUsersForWorkspaceQuery, List<UserDto>>
{
    private readonly IRepositoryUser _userRepository;

    public GetUsersForWorkspaceQueryHandler(IRepositoryUser userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> Handle(GetUsersForWorkspaceQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUsersForWorkspaceAsync(request.WorkspaceId);
    }
}
