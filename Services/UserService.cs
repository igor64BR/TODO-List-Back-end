using Microsoft.AspNetCore.Identity;
using static TodoListBackend.Services.UserServiceAggregator.UserService;

namespace TodoListBackend.Services.UserServiceAggregator
{
    public interface IUserService
    {
        Task<IResult> RegisterUserAsync(RegisterUserDto dto);
        Task<IResult> LoginAsync(LoginDto dto);
    }

    public partial class UserService(
        UserManager<IdentityUser> userManager,
        IJwtService jwtService) : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<IResult> RegisterUserAsync(RegisterUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
                return Results.Conflict("User already exists");

            user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                NormalizedEmail = dto.Email.Normalize(),
                NormalizedUserName = dto.Email.Normalize(),
                LockoutEnabled = false,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
                return Results.Created();

            var errors = result.Errors.Select(e => e.Description);

            return Results.BadRequest(errors);
        }

        public async Task<IResult> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return Results.NotFound("User not found");

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordIsCorrect)
                return Results.Unauthorized();

            var token = jwtService.GenerateToken(user);

            return Results.Ok(token);
        }
    }
}
