using BistroBook.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BistroBook.Utilitys
{
    public static class TokenHelper
    {
        public static bool CheckEmailAndPassword(Account account, string EnteredPass, string storedPassHash)
        {
            return account == null || !BCrypt.Net.BCrypt.Verify(EnteredPass, storedPassHash);
        }

        public static string GenerateJwtToken(Account account, IConfiguration configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var issuer = configuration["Jwt:Issuer"];
            var audience = configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{account.FirstName} {account.LastName}"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email, account.Email)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
