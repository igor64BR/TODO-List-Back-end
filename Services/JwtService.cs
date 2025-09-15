using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoListBackend.Services
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user);
    }

    public class JwtService(Appsettings appsettings) : IJwtService
    {
        public string GenerateToken(IdentityUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwtSettings = appsettings.Jwt;

            var keyBytes = Encoding.UTF8.GetBytes(jwtSettings.Key);

            var securityKey = new SymmetricSecurityKey(keyBytes);

            var creds = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                signingCredentials: creds);

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;
        }
    }
}
