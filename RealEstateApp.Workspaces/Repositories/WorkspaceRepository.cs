using Dapper;
using RealEstateApp.Contracts.Dtos;
using RealEstateApp.Workspaces.Entities;
using System.Data;

namespace RealEstateApp.Workspaces.Repositories;
public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly IDbConnection _db;

    public WorkspaceRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<List<Workspace>> GetAllAsync()
    {
        var query = "SELECT * FROM Workspaces";
        var result = await _db.QueryAsync<Workspace>(query);
        return result.ToList();
    }

    public async Task<Workspace> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Workspaces WHERE Id = @Id";
        var result = await _db.QueryFirstOrDefaultAsync<Workspace>(query, new { Id = id });
        return result;
    }

    public async Task<int> CreateAsync(Workspace workspace)
    {
        var query = "INSERT INTO Workspaces (Name, Description) VALUES (@Name, @Description) RETURNING Id";
        var result = await _db.ExecuteScalarAsync<int>(query, workspace);
        return result;
    }

    public async Task<bool> UpdateAsync(Workspace workspace)
    {
        var query = "UPDATE Workspaces SET Name = @Name, Description = @Description WHERE Id = @Id";
        var result = await _db.ExecuteAsync(query, workspace);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var query = "DELETE FROM Workspaces WHERE Id = @Id";
        var result = await _db.ExecuteAsync(query, new { Id = id });
        return result > 0;
    }

    public async Task<Workspace?> GetWorkspaceByIdAsync(int workspaceId)
    {
        var sql = "SELECT * FROM workspaces WHERE id = @WorkspaceId";
        return await _db.QuerySingleOrDefaultAsync<Workspace>(sql, new { WorkspaceId = workspaceId });
    }

    Task<WorkspaceDto> IWorkspaceRepository.GetWorkspaceByIdAsync(int id)
    {
        return Task.FromResult(new WorkspaceDto(id, "Workspace 1", "Description PROBA"));
    }
}
