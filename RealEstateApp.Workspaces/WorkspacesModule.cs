using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RealEstateApp.Workspaces.Repositories;

namespace RealEstateApp.Workspaces;
public static class WorkspacesModule
{
    public static IServiceCollection AddWorkspacesModule(this IServiceCollection services)
    {
        services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(WorkspacesModule).Assembly));

        return services;
    }
}
