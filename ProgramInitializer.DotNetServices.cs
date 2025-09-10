using Microsoft.AspNetCore.Identity;

namespace TodoListBackend
{
    public static partial class ProgramInitializer
    {
        private static partial class DotNetServices
        {
            public static void Configure(WebApplicationBuilder builder)
            {
                var appsettings = builder.Configuration
                    .Get<Appsettings>()
                    ?? throw new Exception("Appsettings not initialized.");

                var defaultConnection = appsettings.ConnectionStrings
                    .DefaultConnection;

                builder.Services
                    .AddSqlServer<AppDbContext>(defaultConnection);

                builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            }
        }
    }
}
