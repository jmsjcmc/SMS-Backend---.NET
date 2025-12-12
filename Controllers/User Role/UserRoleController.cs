using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class UserRoleController : ControllerBase, IUserRoleController
    {
        private readonly UserRoleService _userRoleService;
        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpPost("user-role/assign")]
        public async Task<ActionResult<List<UserRoleResponse>>> CreateUserRoleAsync(int userID, List<int?> roleIDs)
        {
            var response = await _userRoleService.CreateUserRoleAsync(userID, roleIDs, User);
            return response;
        }
        [HttpGet("user-role/list")]
        public async Task<ActionResult<List<UserRoleResponse>>> GetListedUserRolesAsync()
        {
            var response = await _userRoleService.GetListedUserRolesAsync();
            return response;
        }
        [HttpGet("user-role/paginate")]
        public async Task<ActionResult<Pagination<UserRoleResponse>>> GetPaginatedUserRolesAsync(
            int pageNumber,
            int pageSize)
        {
            var response = await _userRoleService.GetPaginatedUserRolesAsync(pageNumber, pageSize);
            return response;
        }
    }
}
