using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly ProductInventoryQuery _productInventoryQuery;
        private readonly Db _context;
        private readonly IMapper _mapper;
        public ProductInventoryService(ProductInventoryQuery productInventoryQuery, Db context, IMapper mapper)
        {
            _productInventoryQuery = productInventoryQuery;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductInventoryOnlyResponse?> CreateProductInventoryAsync(CreateProductInventoryRequest request, ClaimsPrincipal creator)
        {
            var newProductInventory = _mapper.Map<ProductInventory>(request);
            newProductInventory.CreatorID = AuthUserHelper.GetUserID(creator);
            newProductInventory.CreatedOn = DateTimeHelper.GetPhilippineStandardTime();
            newProductInventory.ProductInventoryStatus = ProductInventoryStatus.Open;

            await _context.ProductInventories.AddAsync(newProductInventory);
            await _context.SaveChangesAsync();

            return await _productInventoryQuery.ProductInventoryOnlyResponseByIDAsync(newProductInventory.ID);
        }
        public async Task<ProductInventoryOnlyResponse?> PatchProductInventoryByIDAsync(int ID, UpdateProductInventoryRequest request, ClaimsPrincipal updater)
        {
            var query = await _productInventoryQuery.PatchProductInventoryByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var productInventoryLog = new ProductInventoryLog
            {
                ProductInventoryID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.ProductInventoryLogs.AddAsync(productInventoryLog);
            await _context.SaveChangesAsync();

            return await _productInventoryQuery.ProductInventoryOnlyResponseByIDAsync(query.ID);
        }
        public async Task<ProductInventoryOnlyResponse?> DeleteProductInventoryByIDAsync(int ID)
        {
            var query = await _productInventoryQuery.PatchProductInventoryByIDAsync(ID);

            _context.ProductInventories.Remove(query);
            await _context.SaveChangesAsync();

            return await _productInventoryQuery.ProductInventoryOnlyResponseByIDAsync(query.ID);
        }
        public async Task<ProductInventoryOnlyResponse?> GetProductInventoryByIDAsync(int ID)
        {
            return await _productInventoryQuery.ProductInventoryOnlyResponseByIDAsync(ID);
        }
        public async Task<DailyProductInventoryResponse?> GetRemainingInventoryForTheDayByIDAsync(int ID)
        {
            return await _productInventoryQuery.DailyProductInventoryResponseByIDAsync(ID);
        }
        public async Task<Pagination<ProductInventoryOnlyResponse>> GetPaginatedProductInventoryAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm)
        {
            var query = _productInventoryQuery.ProductInventoryOnlyResponseAsync(searchTerm);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<Pagination<DailyProductInventoryResponse>> GetPaginatedRemainingInventoryForTheDayAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm)
        {
            var query = _productInventoryQuery.DailyProductInventoryResponseAsync(searchTerm);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<ProductInventoryOnlyResponse>> GetListedProductInventoryAsync(string? searchTerm)
        {
            return await _productInventoryQuery.ProductInventoryOnlyResponseAsync(searchTerm).ToListAsync();
        }
        public async Task<List<DailyProductInventoryResponse>> GetListedRemainingInventoryForTheDayAsync(string? searchTerm)
        {
            return await _productInventoryQuery.DailyProductInventoryResponseAsync(searchTerm).ToListAsync();
        }
    }
}
