using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class RoleController : ControllerBase, IRoleController
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("role/create")]
        public async Task<ActionResult<RoleOnlyResponse?>> CreateRoleAsync(CreateRoleRequest request)
        {
            var response = await _roleService.CreateRoleAsync(request, User);
            return response;
        }
        [HttpPatch("role/{ID}/patch")]
        public async Task<ActionResult<RoleOnlyResponse?>> PatchRoleByIDAsync(int ID, UpdateRoleRequest request)
        {
            var response = await _roleService.PatchRoleByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("role/{ID}/toggle-status")]
        public async Task<ActionResult<RoleOnlyResponse?>> PatchRoleStatusByIDAsync(int ID, RecordStatus recordStatus)
        {
            var response = await _roleService.PatchRoleStatusByIDAsync((int)ID, recordStatus, User);
            return response;
        }
        [HttpDelete("role/{ID}/delete")]
        public async Task<ActionResult<RoleOnlyResponse?>> DeleteRoleByIDAsync(int ID)
        {
            var response = await _roleService.DeleteRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("role/{ID}")]
        public async Task<ActionResult<RoleOnlyResponse?>> GetRoleByIDAsync(int ID)
        {
            var response = await _roleService.GetRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("roles/paginated")]
        public async Task<ActionResult<Pagination<RoleOnlyResponse>>> GetPaginatedRolesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _roleService.GetPaginatedRolesAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("roles/list")]
        public async Task<ActionResult<List<RoleOnlyResponse>>> GetListedRolesAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _roleService.GetListedRolesAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
