using MediatR;

namespace RealEstateApp.Workspaces.Commands;
public class DeleteWorkspaceCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteWorkspaceCommand(int id)
    {
        Id = id;
    }
}
