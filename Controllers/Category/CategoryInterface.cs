using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface ICategoryController
    {
        Task<ActionResult<CategoryOnlyResponse?>> CreateCategoryAsync(string categoryName);
        Task<ActionResult<CategoryOnlyResponse?>> PatchCategoryByIDAsync(int ID, string categoryName);
        Task<ActionResult<CategoryOnlyResponse?>> PatchCategoryStatusByIDAsync(int ID, RecordStatus recordStatus);
        Task<ActionResult<CategoryOnlyResponse?>> DeleteCategoryByIDAsync(int ID);
        Task<ActionResult<CategoryOnlyResponse?>> GetCategoryByIDAsync(int ID);
        Task<ActionResult<Pagination<CategoryOnlyResponse>>> GetPaginatedCategoriesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<CategoryOnlyResponse>>> GetListedCategoriesAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface ICategoryService
    {
        Task<CategoryOnlyResponse?> CreateCategoryAsync(string categoryName, ClaimsPrincipal creator);
        Task<CategoryOnlyResponse?> PatchCategoryByIDAsync(int ID, string categoryName, ClaimsPrincipal updater);
        Task<CategoryOnlyResponse?> PatchCategoryStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater);
        Task<CategoryOnlyResponse?> DeleteCategoryByIDAsync(int ID);
        Task<CategoryOnlyResponse?> GetCategoryByIDAsync(int ID);
        Task<Pagination<CategoryOnlyResponse>> GetPaginatedCategoriesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<CategoryOnlyResponse>> GetListedCategoriesAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface ICategoryQuery
    {
        Task<Category?> PatchCategoryByIDAsync(int ID);
        Task<CategoryOnlyResponse?> CategoryOnlyResponseByIDAsync(int ID);
        Task<CategoryWithProductsResponse?> CategoryWithProductsResponseByIDAsync(int ID);
        IQueryable<CategoryOnlyResponse> CategoryOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
        IQueryable<CategoryWithProductsResponse> CategoryWithProductsResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
