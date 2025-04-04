using MediatR;
using RealEstateApp.Workspaces.Commands;
using RealEstateApp.Workspaces.Queries;
using RealEstateApp.Workspaces.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RealEstateApp.Contracts.Events;

namespace RealEstateApp.Workspaces;
public static class WorkspacesEndpoints
{
    public static void MapWorkspacesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/workspaces")
                    .WithTags("Workspaces");

        // GET Endpoint
        group.MapGet("/", async (IMediator mediator) =>
        {
            return await mediator.Send(new GetAllWorkspacesQuery());
        });

        // GET/{Id} Endpoint
        group.MapGet("/{id}", async (int id, IMediator mediator) =>
        {
            var result = await mediator.Send(new GetWorkspaceByIdQuery(id));
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        // POST Endpoint
        group.MapPost("/", async (IMediator mediator, CreateWorkspaceCommand command) =>
            {
                var id = await mediator.Send(command);
                return Results.Created($"/workspaces/{id}", id);
            });

        // PUT Endpoint
        group.MapPut("/{id}", async (int id, IMediator mediator, UpdateWorkspaceDto dto) =>
        {
            var command = new UpdateWorkspaceCommand(id, dto);
            var result = await mediator.Send(command);
            return result ? Results.Ok() : Results.NotFound();
        });

        // DELETE Endpoint
        group.MapDelete("/{id}", async (int id, IMediator mediator) =>
        {
            var command = new DeleteWorkspaceCommand(id);
            var result = await mediator.Send(command);
            return result ? Results.NoContent() : Results.NotFound();
        });

        // GET/{Id}/users
        group.MapGet("/{workspaceId}/users", async (int workspaceId, IMediator mediator) =>
        {
            var query = new GetUsersForWorkspaceQuery(workspaceId);
            var users = await mediator.Send(query);
            return users.Any() ? Results.Ok(users) : Results.NotFound();
        });
    }
}
