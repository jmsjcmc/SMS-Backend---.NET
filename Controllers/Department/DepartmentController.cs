using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("department/create")]
        public async Task<ActionResult<DepartmentResponse>> CreateDepartment(string departmentName)
        {
            var response = await _departmentService.CreateDepartment(departmentName);
            return response;
        }
        [HttpPatch("department/update/{id}")]
        public async Task<ActionResult<DepartmentResponse>> UpdateDepartmentByID(string departmentName, int id)
        {
            var response = await _departmentService.UpdateDepartmentByID(departmentName, id);
            return response;
        }
        [HttpPatch("department/toggle-status/{id}")]
        public async Task<ActionResult<DepartmentResponse>> RemoveDepartmentByID(int id)
        {
            var response = await _departmentService.RemoveDepartmentByID(id);
            return response;
        }
        [HttpDelete("department/delete/{id}")]
        public async Task<ActionResult<DepartmentResponse>> DeleteDepartmentByID(int id)
        {
            var response = await _departmentService.DeleteDepartmentByID(id);
            return response;
        }
        [HttpGet("departments/active-list")]
        public async Task<ActionResult<List<DepartmentResponse>>> ActiveDepartmentsList(string searchTerm)
        {
            var response = await _departmentService.ActiveDepartmentsList(searchTerm);
            return response;
        }
        [HttpGet("departments/active-paginated")]
        public async Task<ActionResult<Pagination<DepartmentResponse>>> PaginatedActiveDepartments(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _departmentService.PaginatedActiveDepartments(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("department/list-with-positions")]
        public async Task<ActionResult<List<DepartmentWithPositionResponse>>> DepartmentWithPositionsList(string searchTerm)
        {
            var response = await _departmentService.DepartmentWithPositionsList(searchTerm);
            return response;
        }
        [HttpGet("departments/paginated-with-positions")]
        public async Task<ActionResult<Pagination<DepartmentWithPositionResponse>>> PaginatedDepartmentWithPositions(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _departmentService.PaginatedDepartmentWithPositions(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("departments/list")]
        public async Task<ActionResult<List<DepartmentResponse>>> DepartmentsList(string searchTerm)
        {
            var response = await _departmentService.DepartmentsList(searchTerm);
            return response;
        }
        [HttpGet("departments/paginated")]
        public async Task<ActionResult<Pagination<DepartmentResponse>>> PaginatedDepartments(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _departmentService.PaginatedDepartments(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("department/{id}")]
        public async Task<ActionResult<DepartmentResponse>> GetDepartmentById(int id)
        {
            var response = await _departmentService.GetDepartmentByID(id);
            return response;
        }
        [HttpGet("department/with-positions/{id}")]
        public async Task<ActionResult<DepartmentWithPositionResponse>> GetDepartmentWithPositionsByID(int id)
        {
            var response = await _departmentService.GetDepartmentWithPositionsByID(id);
            return response;
        }
    }
}
