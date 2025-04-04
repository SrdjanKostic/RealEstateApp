using MediatR;
using RealEstateApp.Workspaces.Repositories;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Queries;
public class GetWorkspaceByIdHandler : IRequestHandler<GetWorkspaceByIdQuery, WorkspaceDto>
{
    private readonly IWorkspaceRepository _repository;

    public GetWorkspaceByIdHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkspaceDto> Handle(GetWorkspaceByIdQuery request, CancellationToken cancellationToken)
    {
        var workspace = await _repository.GetByIdAsync(request.Id);
        if (workspace == null)
        {
            return null;
        }

        return new WorkspaceDto
        {
            Name = workspace.Name,
            Description = workspace.Description
        };
    }
}
