namespace TodoListBackend.Services.UserServiceAggregator
{
    public partial class UserService
    {
        public record UserDto(Guid Id, string Email, string? Role);

        public record RegisterUserDto(string Email, string Password);

        public record LoginDto(string Email, string Password);
    }
}
