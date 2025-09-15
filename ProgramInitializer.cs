
using TodoListBackend.Repositories;
using TodoListBackend.Services;

namespace TodoListBackend
{
    public static partial class ProgramInitializer
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            ConfigurationFiles.Configure(builder);
            DotNetServices.Configure(builder);
            JwtConfiguration.Configure(builder);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            // Custom DI extensions
            builder.Services.AddServices();
            builder.Services.AddRepositories();
        }
    }
}
