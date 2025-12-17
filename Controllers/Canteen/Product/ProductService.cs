using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class ProductService : IProductService
    {
        private readonly ProductQuery _productQuery;
        private readonly IMapper _mapper;
        private readonly Db _context;
        public ProductService(ProductQuery productQuery, IMapper mapper, Db context)
        {
            _productQuery = productQuery;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductOnlyResponse?> CreateProductAsync(string productName, ClaimsPrincipal creator)
        {
            var newProduct = new Product
            {
                Name = productName,
                CreatorID = AuthUserHelper.GetUserID(creator),
                CreatedOn = DateTimeHelper.GetPhilippineStandardTime(),
                RecordStatus = RecordStatus.Active
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return await _productQuery.ProductOnlyResponseByIDAsync(newProduct.ID);
        }
        public async Task<ProductWithCategoryResponse?> PatchProductByIDAsync(int ID, UpdateProductRequest request, ClaimsPrincipal updater)
        {
            var query = await _productQuery.PatchProductByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var productLog = new ProductLog
            {
                ProductID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.ProductLogs.AddAsync(productLog);
            await _context.SaveChangesAsync();

            return await _productQuery.ProductWithCategoryResponseByIDAsync(query.ID);
        }
        public async Task<ProductWithCategoryResponse?> PatchProductStatusByIDAsync(int ID, RecordStatus? recordStatus, ClaimsPrincipal updater)
        {
            var query = await _productQuery.PatchProductByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var productLog = new ProductLog
            {
                ProductID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.ProductLogs.AddAsync(productLog);
            await _context.SaveChangesAsync();

            return await _productQuery.ProductWithCategoryResponseByIDAsync(query.ID);
        }
        public async Task<ProductOnlyResponse?> DeleteProductByIDAsync(int ID)
        {
            var query = await _productQuery.PatchProductByIDAsync(ID);

            _context.Products.Remove(query);
            await _context.SaveChangesAsync();

            return await _productQuery.ProductOnlyResponseByIDAsync(query.ID);
        }
        public async Task<ProductWithCategoryResponse?> GetProductByIDAsync(int ID)
        {
            return await _productQuery.ProductWithCategoryResponseByIDAsync(ID);
        }
        public async Task<Pagination<ProductWithCategoryResponse>> GetPaginatedProductsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _productQuery.ProductWithCategoryResponseAsync(searchTerm, recordStatus);

            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<ProductWithCategoryResponse>> GetListedProductsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _productQuery.ProductWithCategoryResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
