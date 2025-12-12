using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IUserController
    {
        Task<ActionResult<LogInResponse>> LogInAsync(LogInRequest request);
        Task<ActionResult<UserOnlyResponse?>> CreateUserAsync(CreateUserRequest request);
        Task<ActionResult<UserOnlyResponse?>> PatchUserByIDAsync(int ID, UpdateUserRequest request);
        Task<ActionResult<UserOnlyResponse?>> PatchUserStatusByIDAsync(int ID, RecordStatus? recordStatus);
        Task<ActionResult<UserOnlyResponse?>> DeleteUserByIDAsync(int ID);
        Task<ActionResult<UserWithRoleResponse?>> GetAuthenticatedUserDetailAsync();
        Task<ActionResult<UserOnlyResponse?>> GetUserByIDAsync(int ID);
        Task<ActionResult<Pagination<UserOnlyResponse>>> GetPaginatedUsersAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<UserOnlyResponse>>> GetListedUsersAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IUserService
    {
        Task<LogInResponse> LogInAsync(LogInRequest request);
        Task<LogInResponse> RefreshAsync(RefreshRequest request);
        Task<UserOnlyResponse?> CreateUserAsync(CreateUserRequest request);
        Task<UserOnlyResponse?> PatchUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal updater);
        Task<UserOnlyResponse?> PatchUserStatusByIDAsync(int ID, RecordStatus? recordStatus, ClaimsPrincipal updater);
        Task<UserOnlyResponse?> DeleteUserByIDAsync(int ID);
        Task<UserWithRoleResponse?> GetAuthenticatedUserDetailAsync(ClaimsPrincipal authenticated);
        Task<UserOnlyResponse?> GetUserByIDAsync(int ID);
        Task<Pagination<UserOnlyResponse>> GetPaginatedUsersAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<UserOnlyResponse>> GetListedUsersAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IUserQuery
    {
        Task<User?> PatchUserByIDAsync(int ID);
        Task<UserOnlyResponse?> UserOnlyResponseByIDAsync(int ID);
        IQueryable<UserOnlyResponse> UserOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
