using Microsoft.AspNetCore.Identity;

namespace TodoListBackend.Services.UserServiceAggregator
{
    public interface IUserService
    {

    }

    public class UserService(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager) : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        //public async Task<List<UserDto>>
    }
}
