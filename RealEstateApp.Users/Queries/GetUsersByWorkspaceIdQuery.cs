using MediatR;
using RealEstateApp.Users.Dtos;

namespace RealEstateApp.Users.Queries;
    public class GetUsersByWorkspaceIdQuery: IRequest<List<UserDto>>
    {
        public int WorkspaceId { get; }

        public GetUsersByWorkspaceIdQuery(int workspaceId)
        {
            WorkspaceId = workspaceId;
        }
    }
