using TodoListBackend.Services;

namespace TodoListBackend.Repositories
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
