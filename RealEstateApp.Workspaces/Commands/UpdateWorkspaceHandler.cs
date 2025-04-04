using MediatR;
using RealEstateApp.Workspaces.Repositories;

namespace RealEstateApp.Workspaces.Commands;
public class UpdateWorkspaceHandler : IRequestHandler<UpdateWorkspaceCommand, bool>
{
    private readonly IWorkspaceRepository _repository;

    public UpdateWorkspaceHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = await _repository.GetByIdAsync(request.Workspace.Id);
        if (workspace == null) return false;

        workspace.Name = request.Workspace.Name;
        workspace.Description = request.Workspace.Description;

        var updated = await _repository.UpdateAsync(workspace);
        return updated;
    }
}
