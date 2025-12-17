using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IDailyConsumptionController
    {
        Task<ActionResult<DailyConsumptionOnlyResponse?>> CreateDailyConsumptionAsync(CreateDailyConsumptionRequest request);
        Task<ActionResult<DailyConsumptionOnlyResponse?>> PatchDailyConsumptionByIDAsync(int ID, UpdateDailyConsumptionRequest request);
        Task<ActionResult<DailyConsumptionOnlyResponse?>> PatchInventoryStatusByIDAsync(int ID, ProductConsumptionStatus? productConsumptionStatus);
        Task<ActionResult<DailyConsumptionOnlyResponse?>> DeleteDailyConsumptionByIDAsync(int ID);
        Task<ActionResult<DailyConsumptionOnlyResponse?>> GetDailyConsumptionByIDAsync(int ID);
        Task<ActionResult<Pagination<DailyConsumptionOnlyResponse>>> GetPaginatedDailyConsumptionAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            ProductConsumptionStatus? productConsumptionStatus);
        Task<ActionResult<List<DailyConsumptionOnlyResponse>>> GetListedDailyConsumptionAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus);
    }
    public interface IDailyConsumptionService
    {
        Task<DailyConsumptionOnlyResponse?> CreateDailyConsumptionAsync(CreateDailyConsumptionRequest request, ClaimsPrincipal creator);
        Task<DailyConsumptionOnlyResponse?> PatchDailyConsumptionByIDAsync(int ID, UpdateDailyConsumptionRequest request, ClaimsPrincipal updater);
        Task<DailyConsumptionOnlyResponse?> PatchInventoryStatusByIDAsync(int ID, ProductConsumptionStatus? productConsumptionStatus, ClaimsPrincipal updater);
        Task<DailyConsumptionOnlyResponse?> DeleteDailyConsumptionByIDAsync(int ID);
        Task<DailyConsumptionOnlyResponse?> GetDailyConsumptionByIDAsync(int ID);
        Task<Pagination<DailyConsumptionOnlyResponse>> GetPaginatedDailyConsumptionAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            ProductConsumptionStatus? productConsumptionStatus);
        Task<List<DailyConsumptionOnlyResponse>> GetListedDailyConsumptionAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus);
    }
    public interface IDailyConsumptionQuery
    {
        Task<DailyConsumption?> PatchDailyConsumptionByIDAsync(int ID);
        Task<DailyConsumptionOnlyResponse?> DailyConsumptionOnlyResponseByIDAsync(int ID);
        IQueryable<DailyConsumptionOnlyResponse> DailyConsumptionOnlyResponseAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus);
    }
}
