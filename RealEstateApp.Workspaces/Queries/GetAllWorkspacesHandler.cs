using MediatR;
using RealEstateApp.Workspaces.Repositories;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Queries;
public class GetAllWorkspacesHandler : IRequestHandler<GetAllWorkspacesQuery, List<WorkspaceDto>>
{
    private readonly IWorkspaceRepository _repository;

    public GetAllWorkspacesHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkspaceDto>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
    {
        var workspaces = await _repository.GetAllAsync();
        return workspaces.Select(ws => new WorkspaceDto
        {
            Name = ws.Name,
            Description = ws.Description
        }).ToList();
    }
}
