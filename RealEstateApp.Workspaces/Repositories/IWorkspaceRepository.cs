using RealEstateApp.Contracts.Dtos;
using RealEstateApp.Workspaces.Entities;

namespace RealEstateApp.Workspaces.Repositories;
public interface IWorkspaceRepository
{
    Task<List<Workspace>> GetAllAsync();
    Task<Workspace> GetByIdAsync(int id);
    Task<int> CreateAsync(Workspace workspace);
    Task<bool> UpdateAsync(Workspace workspace);
    Task<bool> DeleteAsync(int id);

    Task<WorkspaceDto> GetWorkspaceByIdAsync(int id);
}
