using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IPositionController
    {
        Task<ActionResult<PositionOnlyResponse?>> CreatePositionAsync(CreatePositionRequest request);
        Task<ActionResult<PositionWithDepartmentResponse>> PatchPositionByIDAsync(int ID, UpdatePositionRequest request);
        Task<ActionResult<PositionWithDepartmentResponse>> PatchPositionStatusByIDAsync(int ID, RecordStatus recordStatus);
        Task<ActionResult<PositionWithDepartmentResponse>> AddPositionToDepartmentByIDAsync(int positionID, int departmentID);
        Task<ActionResult<PositionWithDepartmentResponse>> DeletePositionByIDAsync(int ID);
        Task<ActionResult<PositionWithDepartmentResponse>> GetPositionByIDAsync(int ID);
        Task<ActionResult<Pagination<PositionOnlyResponse>>> GetPaginatedPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<Pagination<PositionWithDepartmentResponse>>> GetPaginatedPositionsWithDepartmentAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<PositionOnlyResponse>>> GetListedPositionsAsync(string? searchTerm, RecordStatus? recordStatus);
        Task<ActionResult<List<PositionWithDepartmentResponse>>> GetListedPositionsWithDepartmentAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IPositionService
    {
        Task<PositionOnlyResponse?> CreatePositionAsync(CreatePositionRequest request, ClaimsPrincipal creator);
        Task<PositionWithDepartmentResponse> PatchPositionByIDAsync(int ID, UpdatePositionRequest request, ClaimsPrincipal updater);
        Task<PositionWithDepartmentResponse> PatchPositionStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater);
        Task<PositionWithDepartmentResponse> AddPositionToDepartmentByIDAsync(int positionID, int departmentID, ClaimsPrincipal updater);
        Task<PositionWithDepartmentResponse> DeletePositionByIDAsync(int ID);
        Task<PositionWithDepartmentResponse> GetPositionByIDAsync(int ID);
        Task<Pagination<PositionOnlyResponse>> GetPaginatedPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<Pagination<PositionWithDepartmentResponse>> GetPaginatedPositionsWithDepartmentAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<PositionOnlyResponse>> GetListedPositionsAsync(string? searchTerm, RecordStatus? recordStatus);
        Task<List<PositionWithDepartmentResponse>> GetListedPositionsWithDepartmentAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IPositionQuery
    {
        Task<Position?> PatchPositionByIDAsync(int ID);
        Task<PositionOnlyResponse?> PositionOnlyResponseByIDAsync(int ID);
        Task<PositionWithDepartmentResponse?> PositionWithDepartmentResponseByIDAsync(int ID);
        IQueryable<PositionOnlyResponse> PositionOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
        IQueryable<PositionWithDepartmentResponse> PositionWithDepartmentResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
