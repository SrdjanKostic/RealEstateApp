using MediatR;
using RealEstateApp.Workspaces.Repositories;
using RealEstateApp.Workspaces.Entities;

namespace RealEstateApp.Workspaces.Commands;
public class CreateWorkspaceHandler : IRequestHandler<CreateWorkspaceCommand, int>
{
    private readonly IWorkspaceRepository _repository;

    public CreateWorkspaceHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = new Workspace
        {
            Name = request.Workspace.Name,
            Description = request.Workspace.Description
        };

        var newWorkspaceId = await _repository.CreateAsync(workspace);
        return newWorkspaceId;
    }
}
