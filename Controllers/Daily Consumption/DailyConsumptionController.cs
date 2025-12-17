using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class DailyConsumptionController : ControllerBase, IDailyConsumptionController
    {
        private readonly DailyConsumptionService _dailyConsumptionService;
        public DailyConsumptionController(DailyConsumptionService dailyConsumptionService)
        {
            _dailyConsumptionService = dailyConsumptionService;
        }
        [HttpPost("daily-consumption/create")]
        public async Task<ActionResult<DailyConsumptionOnlyResponse?>> CreateDailyConsumptionAsync(CreateDailyConsumptionRequest request)
        {
            var response = await _dailyConsumptionService.CreateDailyConsumptionAsync(request, User);
            return response;
        }
        [HttpPatch("daily-consumption/{ID}/patch")]
        public async Task<ActionResult<DailyConsumptionOnlyResponse?>> PatchDailyConsumptionByIDAsync(int ID, UpdateDailyConsumptionRequest request)
        {
            var response = await _dailyConsumptionService.PatchDailyConsumptionByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("daily-consumption/{ID}/toggle-inventory-status")]
        public async Task<ActionResult<DailyConsumptionOnlyResponse?>> PatchInventoryStatusByIDAsync(int ID, ProductConsumptionStatus? productConsumptionStatus)
        {
            var response = await _dailyConsumptionService.PatchInventoryStatusByIDAsync(ID, productConsumptionStatus, User);
            return response;
        }
        [HttpDelete("daily-consumption/{ID}/delete")]
        public async Task<ActionResult<DailyConsumptionOnlyResponse?>> DeleteDailyConsumptionByIDAsync(int ID)
        {
            var response = await _dailyConsumptionService.DeleteDailyConsumptionByIDAsync(ID);
            return response;
        }
        [HttpGet("daily-consumption/{ID}")]
        public async Task<ActionResult<DailyConsumptionOnlyResponse?>> GetDailyConsumptionByIDAsync(int ID)
        {
            var response = await _dailyConsumptionService.GetDailyConsumptionByIDAsync(ID);
            return response;
        }
        [HttpGet("daily-consumption/paginate")]
        public async Task<ActionResult<Pagination<DailyConsumptionOnlyResponse>>> GetPaginatedDailyConsumptionAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            ProductConsumptionStatus? productConsumptionStatus)
        {
            var response = await _dailyConsumptionService.GetPaginatedDailyConsumptionAsync(pageNumber, pageSize, searchTerm, productConsumptionStatus);
            return response;
        }
        [HttpGet("daily-consumption/list")]
        public async Task<ActionResult<List<DailyConsumptionOnlyResponse>>> GetListedDailyConsumptionAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus)
        {
            var response = await _dailyConsumptionService.GetListedDailyConsumptionAsync(searchTerm, productConsumptionStatus);
            return response;
        }
    }
}
