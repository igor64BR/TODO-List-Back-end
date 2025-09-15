using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace TodoListBackend
{
    public partial class ProgramInitializer
    {
        private static class JwtConfiguration
        {
            public static void Configure(WebApplicationBuilder builder)
            {
                var appsettings = builder.Configuration
                    .Get<Appsettings>()
                    ?? throw new Exception("Appsettings not initialized.");

                var requireAuthPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                builder.Services
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Audience = appsettings.Jwt
                            .Audience;
                    });
            }
        }
    }
}
