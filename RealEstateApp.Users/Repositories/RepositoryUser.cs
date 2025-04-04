using Dapper;
using RealEstateApp.Contracts.Dtos;
using System.Data;

namespace RealEstateApp.Users.Repositories;
public class RepositoryUser : IRepositoryUser
{
    private readonly IDbConnection _dbConnection;

    public RepositoryUser(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<List<UserDto>> GetUsersForWorkspaceAsync(int workspaceId)
    {
        var query = @"
            SELECT u.id, u.name, u.email
            FROM Users_ u
            JOIN user_workspaces uw ON u.id = uw.user_id
            WHERE uw.workspace_id = @WorkspaceId";

        var users = await _dbConnection.QueryAsync<UserDto>(query, new { WorkspaceId = workspaceId });

        return users.ToList();
    }
}
