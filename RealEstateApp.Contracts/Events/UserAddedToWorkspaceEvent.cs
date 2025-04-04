namespace RealEstateApp.Contracts.Events;
public class UserAddedToWorkspaceEvent
{
    public int UserId { get; }
    public int WorkspaceId { get; }

    public UserAddedToWorkspaceEvent(int userId, int workspaceId)
    {
        UserId = userId;
        WorkspaceId = workspaceId;
    }
}
