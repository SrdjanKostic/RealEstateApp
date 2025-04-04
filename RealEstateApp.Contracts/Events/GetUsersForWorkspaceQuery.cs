using MediatR;
using RealEstateApp.Contracts.Dtos;

namespace RealEstateApp.Contracts.Events;

public class GetUsersForWorkspaceQuery : IRequest<List<UserDto>>
{
    public int WorkspaceId { get; }

    public GetUsersForWorkspaceQuery(int workspaceId)
    {
        WorkspaceId = workspaceId;
    }
}
