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
        [HttpGet("users/list")]
        public async Task<ActionResult<List<UserResponse>>> UsersList(string? searchTerm)
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
    }
}
