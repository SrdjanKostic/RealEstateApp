using MediatR;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Commands;
public class CreateWorkspaceCommand : IRequest<int>
{
    public CreateWorkspaceDto Workspace { get; set; }

    public CreateWorkspaceCommand(CreateWorkspaceDto workspace)
    {
        Workspace = workspace;
    }
}
