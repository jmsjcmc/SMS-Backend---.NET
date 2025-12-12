using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class RoleService : IRoleService
    {
        private readonly RoleQuery _roleQuery;
        private readonly Db _context;
        private readonly IMapper _mapper;
        public RoleService(RoleQuery roleQuery, Db context, IMapper mapper)
        {
            _roleQuery = roleQuery;
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoleOnlyResponse?> CreateRoleAsync(CreateRoleRequest request, ClaimsPrincipal creator)
        {
            var newRole = _mapper.Map<Role>(request);
            newRole.CreatorID = AuthUserHelper.GetUserID(creator);
            newRole.CreatedOn = DateTimeHelper.GetPhilippineStandardTime();
            newRole.RecordStatus = RecordStatus.Active;

            await _context.Roles.AddAsync(newRole);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(newRole.ID);
        }
        public async Task<RoleOnlyResponse?> PatchRoleByIDAsync(int ID, UpdateRoleRequest request, ClaimsPrincipal updater)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.RoleLogs.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RoleOnlyResponse?> PatchRoleStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.RoleLogs.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RoleOnlyResponse?> DeleteRoleByIDAsync(int ID)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            _context.Roles.Remove(query);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(ID);
        }
        public async Task<RoleOnlyResponse?> GetRoleByIDAsync(int ID)
        {
            return await _roleQuery.RoleOnlyResponseByIDAsync(ID);
        }
        public async Task<Pagination<RoleOnlyResponse>> GetPaginatedRolesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _roleQuery.RoleOnlyResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<RoleOnlyResponse>> GetListedRolesAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _roleQuery.RoleOnlyResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
