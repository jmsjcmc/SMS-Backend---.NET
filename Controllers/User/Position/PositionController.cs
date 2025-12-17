using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class PositionController : ControllerBase, IPositionController
    {
        private readonly PositionService _positionService;
        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpPost("position/create")]
        public async Task<ActionResult<PositionOnlyResponse?>> CreatePositionAsync(CreatePositionRequest request)
        {
            var response = await _positionService.CreatePositionAsync(request, User);
            return response;
        }
        [HttpPatch("position/{ID}/patch")]
        public async Task<ActionResult<PositionWithDepartmentResponse?>> PatchPositionByIDAsync(int ID, UpdatePositionRequest request)
        {
            var response = await _positionService.PatchPositionByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("position/{ID}/toggle-status")]
        public async Task<ActionResult<PositionWithDepartmentResponse?>> PatchPositionStatusByIDAsync(int ID, RecordStatus recordStatus)
        {
            var response = await _positionService.PatchPositionStatusByIDAsync(ID, recordStatus, User);
            return response;
        }
        [HttpPatch("position/{positionID}/add-department")]
        public async Task<ActionResult<PositionWithDepartmentResponse?>> AddPositionToDepartmentByIDAsync(int positionID, int departmentID)
        {
            var response = await _positionService.AddPositionToDepartmentByIDAsync(positionID, departmentID, User);
            return response;
        }
        [HttpDelete("position/{ID}/delete")]
        public async Task<ActionResult<PositionWithDepartmentResponse?>> DeletePositionByIDAsync(int ID)
        {
            var response = await _positionService.DeletePositionByIDAsync(ID);
            return response;
        }
        [HttpGet("position/{ID}")]
        public async Task<ActionResult<PositionWithDepartmentResponse?>> GetPositionByIDAsync(int ID)
        {
            var response = await _positionService.GetPositionByIDAsync(ID);
            return response;
        }
        [HttpGet("positions/paginate")]
        public async Task<ActionResult<Pagination<PositionOnlyResponse>>> GetPaginatedPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _positionService.GetPaginatedPositionsAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("positions/paginate/with-department")]
        public async Task<ActionResult<Pagination<PositionWithDepartmentResponse>>> GetPaginatedPositionsWithDepartmentAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _positionService.GetPaginatedPositionsWithDepartmentAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("positions/list")]
        public async Task<ActionResult<List<PositionOnlyResponse>>> GetListedPositionsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _positionService.GetListedPositionsAsync(searchTerm, recordStatus);
            return response;
        }
        [HttpGet("positions/list/with-department")]
        public async Task<ActionResult<List<PositionWithDepartmentResponse>>> GetListedPositionsWithDepartmentAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _positionService.GetListedPositionsWithDepartmentAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
