using MediatR;
using RealEstateApp.Workspaces.Dtos;

namespace RealEstateApp.Workspaces.Queries;
public class GetAllWorkspacesQuery : IRequest<List<WorkspaceDto>>
{
}
