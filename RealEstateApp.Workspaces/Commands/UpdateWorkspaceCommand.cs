using MediatR;
using RealEstateApp.Workspaces.Dtos;

public class UpdateWorkspaceCommand : IRequest<bool>
{
    public int Id { get; set; }
    public UpdateWorkspaceDto Workspace { get; set; }

    public UpdateWorkspaceCommand(int id, UpdateWorkspaceDto workspace)
    {
        Id = id;
        Workspace = workspace;
    }
}
