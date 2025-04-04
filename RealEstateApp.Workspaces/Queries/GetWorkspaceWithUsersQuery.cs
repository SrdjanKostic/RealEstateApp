using MediatR;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Queries;
    public class GetWorkspaceWithUsersQuery : IRequest<WorkspaceWithUsersDto>
{
        public int WorkspaceId { get; }

        public GetWorkspaceWithUsersQuery(int workspaceId)
        {
            WorkspaceId = workspaceId;
        }
    }
