using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("user/log-in")]
        public async Task<ActionResult<LogInResponse>> LogInAsync(LogInRequest request)
        {
            var response = await _userService.LogInAsync(request);
            return response;
        }
        [HttpPost("user/create")]
        public async Task<ActionResult<UserOnlyResponse?>> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _userService.CreateUserAsync(request);
            return response;
        }
        [HttpPatch("user/{ID}/patch")]
        public async Task<ActionResult<UserOnlyResponse?>> PatchUserByIDAsync(int ID, UpdateUserRequest request)
        {
            var response = await _userService.PatchUserByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("user/{ID}/toggle-status")]
        public async Task<ActionResult<UserOnlyResponse?>> PatchUserStatusByIDAsync(int ID, RecordStatus? recordStatus)
        {
            var response = await _userService.PatchUserStatusByIDAsync(ID, recordStatus, User);
            return response;
        }
        [HttpPatch("user/{ID}/delete")]
        public async Task<ActionResult<UserOnlyResponse?>> DeleteUserByIDAsync(int ID)
        {
            var response = await _userService.DeleteUserByIDAsync(ID);
            return response;
        }
        [HttpGet("user/me")]
        public async Task<ActionResult<UserWithRoleResponse?>> GetAuthenticatedUserDetailAsync()
        {
            var response = await _userService.GetAuthenticatedUserDetailAsync(User);
            return response;
        }
        [HttpGet("user/{ID}")]
        public async Task<ActionResult<UserOnlyResponse?>> GetUserByIDAsync(int ID)
        {
            var response = await _userService.GetUserByIDAsync(ID);
            return response;
        }
        [HttpGet("users/paginated")]
        public async Task<ActionResult<Pagination<UserOnlyResponse>>> GetPaginatedUsersAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _userService.GetPaginatedUsersAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("users/list")]
        public async Task<ActionResult<List<UserOnlyResponse>>> GetListedUsersAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _userService.GetListedUsersAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
