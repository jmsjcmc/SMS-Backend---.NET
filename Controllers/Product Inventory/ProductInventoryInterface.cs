using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IProductInventoryController
    {
        Task<ActionResult<ProductInventoryOnlyResponse?>> CreateProductInventoryAsync(CreateProductInventoryRequest request);
        Task<ActionResult<ProductInventoryOnlyResponse?>> PatchProductInventoryByIDAsync(int ID, UpdateProductInventoryRequest request);
        Task<ActionResult<ProductInventoryOnlyResponse?>> DeleteProductInventoryByIDAsync(int ID);
        Task<ActionResult<ProductInventoryOnlyResponse?>> GetProductInventoryByIDAsync(int ID);
        Task<ActionResult<DailyProductInventoryResponse?>> GetRemainingInventoryForTheDayByIDAsync(int ID);
        Task<ActionResult<Pagination<ProductInventoryOnlyResponse>>> GetPaginatedProductInventoryAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm);
        Task<ActionResult<Pagination<DailyProductInventoryResponse>>> GetPaginatedRemainingInventoryForTheDayAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm);
        Task<ActionResult<List<ProductInventoryOnlyResponse>>> GetListedProductInventoryAsync(string? searchTerm);
        Task<ActionResult<List<DailyProductInventoryResponse>>> GetListedRemainingInventoryForTheDayAsync(string? searchTerm);
    }
    public interface IProductInventoryService
    {
        Task<ProductInventoryOnlyResponse?> CreateProductInventoryAsync(CreateProductInventoryRequest request, ClaimsPrincipal creator);
        Task<ProductInventoryOnlyResponse?> PatchProductInventoryByIDAsync(int ID, UpdateProductInventoryRequest request, ClaimsPrincipal updater);
        Task<ProductInventoryOnlyResponse?> DeleteProductInventoryByIDAsync(int ID);
        Task<ProductInventoryOnlyResponse?> GetProductInventoryByIDAsync(int ID);
        Task<DailyProductInventoryResponse?> GetRemainingInventoryForTheDayByIDAsync(int ID);
        Task<Pagination<ProductInventoryOnlyResponse>> GetPaginatedProductInventoryAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm);
        Task<Pagination<DailyProductInventoryResponse>> GetPaginatedRemainingInventoryForTheDayAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm);
        Task<List<ProductInventoryOnlyResponse>> GetListedProductInventoryAsync(string? searchTerm);
        Task<List<DailyProductInventoryResponse>> GetListedRemainingInventoryForTheDayAsync(string? searchTerm);
    }
    public interface IProductInventoryQuery
    {
        Task<ProductInventory?> PatchProductInventoryByIDAsync(int ID);
        Task<ProductInventoryOnlyResponse?> ProductInventoryOnlyResponseByIDAsync(int ID);
        Task<DailyProductInventoryResponse?> DailyProductInventoryResponseByIDAsync(int ID);
        IQueryable<ProductInventoryOnlyResponse> ProductInventoryOnlyResponseAsync(string? searchTerm);
        IQueryable<DailyProductInventoryResponse> DailyProductInventoryResponseAsync(string? searchTerm);
    }
}
