using Microsoft.EntityFrameworkCore;
using SMS_backend.Models.Entities;

namespace SMS_backend.Controllers
{
    public class UserQueries
    {
        private readonly Db _context;
        public UserQueries(Db context)
        {
            _context = context;
        }
        public async Task<List<User>> UsersList(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.User
                    .AsNoTracking()
                    .Where(u => u.Username.Contains(searchTerm) ||
                    u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm))
                    .OrderByDescending(u => u.Id)
                    .ToListAsync();
            }
            else
            {
                return await _context.User
                    .AsNoTracking()
                    .OrderByDescending(u => u.Id)
                    .ToListAsync();
            }
        }
        public IQueryable<User> PaginatedUsers(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.User
                    .AsNoTracking()
                    .Where(u => u.Username.Contains(searchTerm) ||
                    u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm))
                    .OrderByDescending(u => u.Id)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.User
                    .AsNoTracking()
                    .OrderByDescending(u => u.Id)
                    .AsQueryable();

                return query;
            }
        }
    }
}
