using RealEstateApp.Contracts.Dtos;

namespace RealEstateApp.Users.Repositories;
public interface IRepositoryUser
{
    Task<List<UserDto>> GetUsersForWorkspaceAsync(int workspaceId);
}
