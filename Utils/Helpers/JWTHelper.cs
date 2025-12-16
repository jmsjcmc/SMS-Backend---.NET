using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SMS_backend.Utils
{
    public class JWTHelper
    {
        private readonly IConfiguration _configuration;
        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(int userID, string username, List<string> roles)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim("UserID", userID.ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtIssuer,
                claims: claims,
                expires: DateTimeHelper.GetPhilippineStandardTime().AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var RNG = RandomNumberGenerator.Create();
            RNG.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
