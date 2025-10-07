using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("user/create")]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _userService.CreateUser(request);
            return response;
        }
        [HttpPatch("user/update/{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUserByID([FromBody] UpdateUserRequest request, Guid id)
        {
            var response = await _userService.UpdateUserByID(request, id);
            return response;
        }
        [HttpPatch("user/toggle-status/{id}")]
        public async Task<ActionResult<UserResponse>> RemoveUserByID(Guid id)
        {
            var response = await _userService.RemoveUserByID(id);
            return response;
        }
        [HttpDelete("user/delete/{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUserByID(Guid id)
        {
            var response = await _userService.DeleteUserByID(id);
            return response;
        }
        [HttpGet("users/active-list")]
        public async Task<ActionResult<List<UserResponse>>> ActiveUsersList(string searchTerm)
        {
            var response = await _userService.ActiveUsersList(searchTerm);
            return response;
        }
        [HttpGet("users/active-paginated")]
        public async Task<ActionResult<Pagination<UserResponse>>> PaginatedActiveUsers(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null)
        {
            var response = await _userService.PaginatedActiveUsers(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("users/list")]
        public async Task<ActionResult<List<UserResponse>>> UsersList(string searchTerm)
        {
            var response = await _userService.UsersList(searchTerm);
            return response;
        }
        [HttpGet("users/paginated")]
        public async Task<ActionResult<Pagination<UserResponse>>> PaginatedUsers(int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            var response = await _userService.PaginatedUsers(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserResponse>> GetUserByID(Guid id)
        {
            var response = await _userService.GetUserByID(id);
            return response;
        }
    }
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("role/create")]
        public async Task<ActionResult<RoleResponse>> CreateRole(string roleName)
        {
            var response = await _roleService.CreateRole(roleName);
            return response;
        }
        [HttpPatch("role/update/{id}")]
        public async Task<ActionResult<RoleResponse>> UpdateRoleByID(string roleName, Guid id)
        {
            var response = await _roleService.UpdateRoleByID(roleName, id);
            return response;
        }
        [HttpPatch("role/toggle-status/{id}")]
        public async Task<ActionResult<RoleResponse>> RemoveRoleByID(Guid id)
        {
            var response = await _roleService.RemoveRoleByID(id);
            return response;
        }
        [HttpDelete("role/delete/{id}")]
        public async Task<ActionResult<RoleResponse>> DeleteRoleByID(Guid id)
        {
            var response = await _roleService.DeletRoleByID(id);
            return response;
        }
        [HttpGet("roles/active-list")]
        public async Task<ActionResult<List<RoleResponse>>> ActiveRolesList(string searchTerm)
        {
            var response = await _roleService.ActiveRolesList(searchTerm);
            return response;
        }
        [HttpGet("roles/active-paginated")]
        public async Task<ActionResult<Pagination<RoleResponse>>> PaginatedActiveRoles(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _roleService.PaginatedActiveRoles(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("roles/list")]
        public async Task<ActionResult<List<RoleResponse>>> RolesList(string searchTerm)
        {
            var response = await _roleService.RolesList(searchTerm);
            return response;
        }
        [HttpGet("roles/paginated")]
        public async Task<ActionResult<Pagination<RoleResponse>>> PaginatedRoles(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _roleService.PaginatedRoles(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("role/{id}")]
        public async Task<ActionResult<RoleResponse>> GetUserByID(Guid id)
        {
            var response = await _roleService.GetRoleByID(id);
            return response;
        }
    }
}
