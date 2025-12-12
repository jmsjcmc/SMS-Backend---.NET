using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IUserRoleController
    {
        Task<ActionResult<List<UserRoleResponse>>> CreateUserRoleAsync(int userID, List<int?> roleIDs);
        Task<ActionResult<List<UserRoleResponse>>> GetListedUserRolesAsync();
        Task<ActionResult<Pagination<UserRoleResponse>>> GetPaginatedUserRolesAsync(
            int pageNumber,
            int pageSize);
    }
    public interface IUserRoleService
    {
        Task<List<UserRoleResponse>> CreateUserRoleAsync(int userID, List<int?> roleIDs, ClaimsPrincipal assigner);
        Task<List<UserRoleResponse>> GetListedUserRolesAsync();
        Task<Pagination<UserRoleResponse>> GetPaginatedUserRolesAsync(
            int pageNumber,
            int pageSize);
    }
    public interface IUserRoleQuery
    {
        Task<UserRoleResponse?> UserRoleResponseByIDAsync(int ID);
        IQueryable<UserRoleResponse> UserRoleResponseAsync();
    }
}
