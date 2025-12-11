using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMS_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SMS_backend.Utils
{
    public class Pagination<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class AuthUserHelper
    {
        private readonly IConfiguration _configuration;
        public AuthUserHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static int GetUserID(ClaimsPrincipal user)
        {
            if (user == null)
                return 0;

            var value = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(value, out int userID))
            {
                return userID;
            }
            return 0;
        }
        public string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            if (user.UserRoles != null && user.UserRoles.Any())
            {
                foreach (var userRole in user.UserRoles)
                {
                    if (userRole.Role != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
                    }
                }
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    public static class PaginationHelper
    {
        public static async Task<Pagination<T>> PaginatedAndMap<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalItems,
                Items = items
            };
        }
    }
    public static class DateTimeHelper // Helper for fetching exact present Philippine time instead of local time
    {
        public static DateTime GetPhilippineStandardTime()
        {
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
            }
            catch
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
            }
        }
    }
}
