using MediatR;
using RealEstateApp.Users.Dtos;
using RealEstateApp.Users.Repositories;
using static RealEstateApp.Users.Repositories.IRepositoryUser;

namespace RealEstateApp.Users.Queries;
    class GetUsersByWorkspaceIdHandler: IRequestHandler<GetUsersByWorkspaceIdQuery, List<UserDto>>
    {
        private readonly IRepositoryUser _userRepository;

        public GetUsersByWorkspaceIdHandler(IRepositoryUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUsersByWorkspaceIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersForWorkspaceAsync(request.WorkspaceId);
            return users.Select(user => new UserDto(user.Id, user.Name, user.Email)).ToList();
        }
    }
