using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public interface IProductController
    {
        Task<ActionResult<ProductOnlyResponse?>> CreateProductAsync(string productName);
        Task<ActionResult<ProductWithCategoryResponse?>> PatchProductByIDAsync(int ID, UpdateProductRequest request);
        Task<ActionResult<ProductWithCategoryResponse?>> PatchProductStatusByIDAsync(int ID, RecordStatus? recordStatus);
        Task<ActionResult<ProductOnlyResponse?>> DeleteProductByIDAsync(int ID);
        Task<ActionResult<ProductWithCategoryResponse?>> GetProductByIDAsync(int ID);
        Task<ActionResult<Pagination<ProductWithCategoryResponse>>> GetPaginatedProductsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<ActionResult<List<ProductWithCategoryResponse>>> GetListedProductsAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IProductService
    {
        Task<ProductOnlyResponse?> CreateProductAsync(string productName, ClaimsPrincipal creator);
        Task<ProductWithCategoryResponse?> PatchProductByIDAsync(int ID, UpdateProductRequest request, ClaimsPrincipal updater);
        Task<ProductWithCategoryResponse?> PatchProductStatusByIDAsync(int ID, RecordStatus? recordStatus, ClaimsPrincipal updater);
        Task<ProductOnlyResponse?> DeleteProductByIDAsync(int ID);
        Task<ProductWithCategoryResponse?> GetProductByIDAsync(int ID);
        Task<Pagination<ProductWithCategoryResponse>> GetPaginatedProductsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus);
        Task<List<ProductWithCategoryResponse>> GetListedProductsAsync(string? searchTerm, RecordStatus? recordStatus);
    }
    public interface IProductQuery
    {
        Task<Product?> PatchProductByIDAsync(int ID);
        Task<ProductOnlyResponse?> ProductOnlyResponseByIDAsync(int ID);
        Task<ProductWithCategoryResponse?> ProductWithCategoryResponseByIDAsync(int ID);
        IQueryable<ProductOnlyResponse> ProductOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus);
        IQueryable<ProductWithCategoryResponse> ProductWithCategoryResponseAsync(string? searchTerm, RecordStatus? recordStatus);
    }
}
