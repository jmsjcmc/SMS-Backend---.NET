using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class UserRoleQuery : IUserRoleQuery
    {
        private readonly Db _context;
        public UserRoleQuery(Db context)
        {
            _context = context;
        }
        public async Task<UserRoleResponse?> UserRoleResponseByIDAsync(int ID)
        {
            return await _context.UserRoles
                .AsNoTracking()
                .Where(UR => UR.ID == ID)
                .Select(UR => new UserRoleResponse
                {
                    ID = UR.ID,
                    UserID = UR.UserID,
                    UserFullName = $"{UR.User.FirstName} {UR.User.LastName}",
                    RoleID = UR.RoleID,
                    RoleName = UR.Role.Name
                }).SingleOrDefaultAsync();
        }
        public IQueryable<UserRoleResponse> UserRoleResponseAsync()
        {
            var query = _context.UserRoles
                .AsNoTracking()
                .AsQueryable();

            return query
                .OrderByDescending(UR => UR.ID)
                .Select(UR => new UserRoleResponse
                {
                    ID = UR.ID,
                    UserID = UR.UserID,
                    UserFullName = $"{UR.User.FirstName} {UR.User.LastName}",
                    RoleID = UR.RoleID,
                    RoleName = UR.Role.Name
                });
        }
    }
}
