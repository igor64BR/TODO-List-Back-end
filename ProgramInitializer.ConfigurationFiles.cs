namespace TodoListBackend
{
    public static partial class ProgramInitializer
    {
        private static class ConfigurationFiles
        {
            public static void Configure(WebApplicationBuilder builder)
            {
                builder.Services.Configure<Appsettings>(builder.Configuration);

                var appsettings = builder.Configuration
                    .Get<Appsettings>()!;

                builder.Services.AddScoped(_ => appsettings);
            }
        }
    }
}
