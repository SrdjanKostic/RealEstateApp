using MediatR;
using RealEstateApp.Workspaces.Repositories;

namespace RealEstateApp.Workspaces.Commands;
public class DeleteWorkspaceHandler : IRequestHandler<DeleteWorkspaceCommand, bool>
{
    private readonly IWorkspaceRepository _repository;

    public DeleteWorkspaceHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = await _repository.GetByIdAsync(request.Id);
        if (workspace == null) return false;

        var deleted = await _repository.DeleteAsync(request.Id);
        return deleted;
    }
}
