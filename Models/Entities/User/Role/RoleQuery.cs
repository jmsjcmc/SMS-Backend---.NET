using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class RoleQuery : IRoleQuery
    {
        private readonly Db _context;
        public RoleQuery(Db context)
        {
            _context = context;
        }
        public async Task<Role?> PatchRoleByIDAsync(int ID)
        {
            return await _context.Roles
                .SingleOrDefaultAsync(R => R.ID == ID);
        }
        public async Task<RoleOnlyResponse?> RoleOnlyResponseByIDAsync(int ID)
        {
            return await _context.Roles
                .AsNoTracking()
                .Where(R => R.ID == ID)
                .Select(R => new RoleOnlyResponse
                {
                    ID = R.ID,
                    Name = R.Name,
                    Description = R.Description,
                    RecordStatus = R.RecordStatus,
                }).SingleOrDefaultAsync();
        }
        public IQueryable<RoleOnlyResponse> RoleOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Roles
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(R => R.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(R => R.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(R => R.ID)
                .Select(R => new RoleOnlyResponse
                {
                    ID = R.ID,
                    Name = R.Name,
                    Description = R.Description,
                    RecordStatus = R.RecordStatus,
                });
        }
    }
}
