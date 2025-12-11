using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class UserQuery : IUserQuery
    {
        private readonly Db _context;
        public UserQuery(Db context)
        {
            _context = context;
        }
        public async Task<User?> PatchUserByIDAsync(int ID)
        {
            return await _context.Users
                .SingleOrDefaultAsync(U => U.ID == ID);
        }
        public async Task<UserOnlyResponse?> UserOnlyResponseByIDAsync(int ID)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(U => U.ID == ID)
                .Select(U => new UserOnlyResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    Avatar = U.Avatar,
                    RecordStatus = U.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<UserOnlyResponse> UserOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Users
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(U => U.FirstName.Contains(searchTerm) ||
                U.LastName.Contains(searchTerm) ||
                U.Username.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(U => U.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(U => U.ID)
                .Select(U => new UserOnlyResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    Avatar = U.Avatar,
                    RecordStatus = U.RecordStatus
                });
        }
    }
}
