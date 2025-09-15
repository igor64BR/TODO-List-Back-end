using TodoListBackend.Services.UserServiceAggregator;

namespace TodoListBackend.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
