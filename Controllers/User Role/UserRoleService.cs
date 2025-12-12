using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserRoleQuery _userRoleQuery;
        private readonly Db _context;
        private readonly IMapper _mapper;
        public UserRoleService(UserRoleQuery userRoleQuery, Db context, IMapper mapper)
        {
            _userRoleQuery = userRoleQuery;
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserRoleResponse>> CreateUserRoleAsync(int userID, List<int?> roleIDs, ClaimsPrincipal assigner)
        {
            var existingRoles = await _context.UserRoles
                .Where(UR => UR.UserID == userID && roleIDs.Contains(UR.RoleID))
                .Select(UR => UR.RoleID)
                .ToListAsync();

            var newRoles = roleIDs
                .Except(existingRoles)
                .Select(roleID => new UserRole
                {
                    UserID = userID,
                    RoleID = roleID,
                    AssignerID = AuthUserHelper.GetUserID(assigner),
                    AssignedOn = DateTimeHelper.GetPhilippineStandardTime()
                }).ToList();

            if (newRoles.Any())
            {
                await _context.UserRoles.AddRangeAsync(newRoles);
                await _context.SaveChangesAsync();
            }

            return await _userRoleQuery.UserRoleResponseAsync()
                .Where(UR => UR.UserID == userID)
                .ToListAsync();
        }
        public async Task<List<UserRoleResponse>> GetListedUserRolesAsync()
        {
            return await _userRoleQuery.UserRoleResponseAsync().ToListAsync();
        }
        public async Task<Pagination<UserRoleResponse>> GetPaginatedUserRolesAsync(
            int pageNumber,
            int pageSize)
        {
            var query = _userRoleQuery.UserRoleResponseAsync();
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
    }
}
