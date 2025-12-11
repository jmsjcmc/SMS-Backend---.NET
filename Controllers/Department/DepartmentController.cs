using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class DepartmentController : ControllerBase, IDepartmentController
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("department/create")]
        public async Task<ActionResult<DepartmentOnlyResponse?>> CreateDepartmentAsync(CreateDepartmentRequest request)
        {
            var response = await _departmentService.CreateDepartmentAsync(request, User);
            return response;
        }
        [HttpPatch("department/{ID}/patch")]
        public async Task<ActionResult<DepartmentWithPositionsResponse?>> PatchDepartmentByIDAsync(int ID, UpdateDepartmentRequest request)
        {
            var response = await _departmentService.PatchDepartmentByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("department/{ID}/toggle-status")]
        public async Task<ActionResult<DepartmentWithPositionsResponse?>> PatchDepartmentStatusByIDAsync(int ID, RecordStatus recordStatus)
        {
            var response = await _departmentService.PatchDepartmentStatusByIDAsync(ID, recordStatus, User);
            return response;
        }
        [HttpDelete("department/{ID}/delete")]
        public async Task<ActionResult<DepartmentWithPositionsResponse?>> DeleteDepartmentByIDAsync(int ID)
        {
            var response = await _departmentService.DeleteDepartmentByIDAsync(ID);
            return response;
        }
        [HttpGet("department/{ID}")]
        public async Task<ActionResult<DepartmentWithPositionsResponse?>> GetDepartmentByIDAsync(int ID)
        {
            var response = await _departmentService.GetDepartmentByIDAsync(ID);
            return response;
        }
        [HttpGet("departments/paginate/with-position")]
        public async Task<ActionResult<Pagination<DepartmentWithPositionsResponse>>> GetPaginatedDepartmentsWithPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _departmentService.GetPaginatedDepartmentsWithPositionsAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("departments/paginate")]
        public async Task<ActionResult<Pagination<DepartmentOnlyResponse>>> GetPaginatedDepartmentsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _departmentService.GetPaginatedDepartmentsAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("departments/list/with-position")]
        public async Task<ActionResult<List<DepartmentWithPositionsResponse>>> GetListedDepartmentsWithPositionsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _departmentService.GetListedDepartmentsWithPositionsAsync(searchTerm, recordStatus);
            return response;
        }
        [HttpGet("departments/list")]
        public async Task<ActionResult<List<DepartmentOnlyResponse>>> GetListedDepartmentsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _departmentService.GetListedDepartmentsAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
