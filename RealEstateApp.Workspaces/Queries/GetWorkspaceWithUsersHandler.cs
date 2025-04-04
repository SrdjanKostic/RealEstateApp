using MediatR;
using RealEstateApp.Workspaces.Dtos;
using RealEstateApp.Workspaces.Repositories;
using RealEstateApp.Contracts.Events;

namespace RealEstateApp.Workspaces.Queries;
    public class GetWorkspaceWithUsersHandler : IRequestHandler<GetWorkspaceWithUsersQuery, WorkspaceWithUsersDto>
{
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly IMediator _mediator;

        public GetWorkspaceWithUsersHandler(IWorkspaceRepository workspaceRepository, IMediator mediator)
        {
            _workspaceRepository = workspaceRepository;
            _mediator = mediator;
        }

        public async Task<WorkspaceWithUsersDto> Handle(GetWorkspaceWithUsersQuery request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceRepository.GetWorkspaceByIdAsync(request.WorkspaceId);
            
            if (workspace == null)
            {
                return null;
            }

            var users = await _mediator.Send(new GetUsersForWorkspaceQuery(request.WorkspaceId));

            return new WorkspaceWithUsersDto(workspace.Id, workspace.Name, users);
        }
    }
