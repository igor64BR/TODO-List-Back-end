using Microsoft.AspNetCore.Mvc;
using TodoListBackend.Services.UserServiceAggregator;

namespace TodoListBackend.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/user", (
                [FromServices] IUserService userService,
                [FromBody] UserService.RegisterUserDto dto) =>
            {
                return userService.RegisterUserAsync(dto);
            });

            app.MapPost("/user/authenticate", (
                [FromServices] IUserService userService,
                [FromBody] UserService.LoginDto dto) =>
            {
                return userService.LoginAsync(dto);
            });
        }
    }
}
