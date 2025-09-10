
using TodoListBackend.Services;

namespace TodoListBackend
{
    public static partial class ProgramInitializer
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            ConfigurationFiles.Configure(builder);
            DotNetServices.Configure(builder);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddServices();
        }
    }
}
