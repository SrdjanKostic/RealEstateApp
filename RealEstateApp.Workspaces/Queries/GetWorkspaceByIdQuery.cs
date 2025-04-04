using MediatR;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Queries;
public class GetWorkspaceByIdQuery : IRequest<WorkspaceDto>
{
    public int Id { get; }

    public GetWorkspaceByIdQuery(int id)
    {
        Id = id;
    }
}
