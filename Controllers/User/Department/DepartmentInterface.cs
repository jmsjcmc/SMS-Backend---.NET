using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IDepartmentController
    {
        Task<ActionResult<DepartmentOnlyResponse?>> CreateDepartmentAsync(CreateDepartmentRequest request);
        Task<ActionResult<DepartmentWithPositionsResponse?>> PatchDepartmentByIDAsync(int ID, UpdateDepartmentRequest request);
        Task<ActionResult<DepartmentWithPositionsResponse?>> PatchDepartmentStatusByIDAsync(int ID, RecordStatus recordStatus);
        Task<ActionResult<DepartmentWithPositionsResponse?>> DeleteDepartmentByIDAsync(int ID);
        Task<ActionResult<DepartmentWithPositionsResponse?>> GetDepartmentByIDAsync(int ID);
        Task<ActionResult<Pagination<DepartmentWithPositionsResponse>>> GetPaginatedDepartmentsWithPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<Pagination<DepartmentOnlyResponse>>> GetPaginatedDepartmentsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<DepartmentWithPositionsResponse>>> GetListedDepartmentsWithPositionsAsync(string? searchTerm, RecordStatus? recordStatus);
        Task<ActionResult<List<DepartmentOnlyResponse>>> GetListedDepartmentsAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IDepartmentService
    {
        Task<DepartmentOnlyResponse?> CreateDepartmentAsync(CreateDepartmentRequest request, ClaimsPrincipal creator);
        Task<DepartmentWithPositionsResponse?> PatchDepartmentByIDAsync(int ID, UpdateDepartmentRequest request, ClaimsPrincipal updater);
        Task<DepartmentWithPositionsResponse?> PatchDepartmentStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater);
        Task<DepartmentWithPositionsResponse?> DeleteDepartmentByIDAsync(int ID);
        Task<DepartmentWithPositionsResponse?> GetDepartmentByIDAsync(int ID);
        Task<Pagination<DepartmentWithPositionsResponse>> GetPaginatedDepartmentsWithPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<Pagination<DepartmentOnlyResponse>> GetPaginatedDepartmentsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<DepartmentWithPositionsResponse>> GetListedDepartmentsWithPositionsAsync(string? searchTerm, RecordStatus? recordStatus);
        Task<List<DepartmentOnlyResponse>> GetListedDepartmentsAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IDeparmentQuery
    {
        Task<Department?> PatchDepartmentByIDAsync(int ID);
        Task<DepartmentOnlyResponse?> DepartmentOnlyResponseByIDAsync(int ID);
        Task<DepartmentWithPositionsResponse?> DepartmentWithPositionsResponseByIDAsync(int ID);
        IQueryable<DepartmentOnlyResponse> DepartmentOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
        IQueryable<DepartmentWithPositionsResponse> DepartmentWithPositionsResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
