using Microsoft.AspNetCore.Mvc;
using TodoListBackend.Services;

namespace TodoListBackend.Endpoints
{
    public static class TodoEndpoints
    {
        public static void MapTodoEndpoints(this WebApplication app)
        {
            app.MapGet("/", async ([FromServices] ITodoRepository repository) =>
            {
                var result = await repository.List();

                return Results.Ok(result);
            });

            app.MapPost("/", ([FromServices] ITodoRepository repository, [FromBody] TodoRepository.CreateDto request) =>
            {
                repository.Create(request);

                return Results.NoContent();
            });
        }
    }
}
