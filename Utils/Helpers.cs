using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMS_backend.Models.Entities;
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };
            if (user.UserRole != null && user.UserRole.Any())
            {
                foreach (var userRole in user.UserRole)
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
    public static class PaginationHelper // Pagination Helper
    {
        public static async Task<List<TDestination>> PaginateAndProject<TSource, TDestination>(
            IQueryable<TSource> query,
            int pageNumber,
            int pageSize,
            IMapper mapper)
        {
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDestination>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public static Pagination<T> PaginatedResponse<T>(
            List<T> items,
            int totalCount,
            int pageNumber,
            int pageSize)
        {
            return new Pagination<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public static async Task<Pagination<TDestination>> PaginateAndMap<TSource, TDestination>(
            IQueryable<TSource> query,
            int pageNumber,
            int pageSize,
            IMapper mapper)
        {
            var totalCount = await query.CountAsync();
            var item = await PaginateAndProject<TSource, TDestination>(query, pageNumber, pageSize, mapper);
            return PaginatedResponse(item, totalCount, pageNumber, pageSize);
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
