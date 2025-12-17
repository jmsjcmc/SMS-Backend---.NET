using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IRoleController
    {
        Task<ActionResult<RoleOnlyResponse?>> CreateRoleAsync(CreateRoleRequest request);
        Task<ActionResult<RoleOnlyResponse?>> PatchRoleByIDAsync(int ID, UpdateRoleRequest request);
        Task<ActionResult<RoleOnlyResponse?>> PatchRoleStatusByIDAsync(int ID, RecordStatus recordStatus);
        Task<ActionResult<RoleOnlyResponse?>> DeleteRoleByIDAsync(int ID);
        Task<ActionResult<RoleOnlyResponse?>> GetRoleByIDAsync(int ID);
        Task<ActionResult<Pagination<RoleOnlyResponse>>> GetPaginatedRolesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<RoleOnlyResponse>>> GetListedRolesAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IRoleService
    {
        Task<RoleOnlyResponse?> CreateRoleAsync(CreateRoleRequest request, ClaimsPrincipal creator);
        Task<RoleOnlyResponse?> PatchRoleByIDAsync(int ID, UpdateRoleRequest request, ClaimsPrincipal updater);
        Task<RoleOnlyResponse?> PatchRoleStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater);
        Task<RoleOnlyResponse?> DeleteRoleByIDAsync(int ID);
        Task<RoleOnlyResponse?> GetRoleByIDAsync(int ID);
        Task<Pagination<RoleOnlyResponse>> GetPaginatedRolesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<RoleOnlyResponse>> GetListedRolesAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IRoleQuery
    {
        Task<Role?> PatchRoleByIDAsync(int ID);
        Task<RoleOnlyResponse?> RoleOnlyResponseByIDAsync(int ID);
        IQueryable<RoleOnlyResponse> RoleOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
