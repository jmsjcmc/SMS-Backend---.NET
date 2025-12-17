using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class ProductInventoryQuery : IProductInventoryQuery
    {
        private readonly Db _context;
        public ProductInventoryQuery(Db context)
        {
            _context = context;
        }
        public async Task<ProductInventory?> PatchProductInventoryByIDAsync(int ID)
        {
            return await _context.ProductInventories
                .SingleOrDefaultAsync(PI => PI.ID == ID);
        }
        public async Task<ProductInventoryOnlyResponse?> ProductInventoryOnlyResponseByIDAsync(int ID)
        {
            return await _context.ProductInventories
                .AsNoTracking()
                .Where(PI => PI.ID == ID)
                .Select(PI => new ProductInventoryOnlyResponse
                {
                    ID = PI.ID,
                    ProductName = PI.Product.Name,
                    Quantity = PI.Quantity,
                    DateInventory = PI.DateInventory
                }).SingleOrDefaultAsync();
        }
        public async Task<DailyProductInventoryResponse?> DailyProductInventoryResponseByIDAsync(int ID)
        {
            return await _context.ProductInventories
                .AsNoTracking()
                .Where(PI => PI.ID == ID)
                .Select(PI => new DailyProductInventoryResponse
                {
                    ID = PI.ID,
                    ProductName = PI.Product.Name,
                    RemainingQuantity = PI.DailyConsumptions.Select(DC => DC.Quantity).FirstOrDefault() - PI.Quantity,
                    DateInventory = PI.DateInventory
                }).SingleOrDefaultAsync();
        }
        public IQueryable<ProductInventoryOnlyResponse> ProductInventoryOnlyResponseAsync(string? searchTerm)
        {
            var query = _context.ProductInventories
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(PI => PI.Product.Name.Contains(searchTerm));
            }

            return query
                .OrderByDescending(PI => PI.ID)
                .Select(PI => new ProductInventoryOnlyResponse
                {
                    ID = PI.ID,
                    ProductName = PI.Product.Name,
                    Quantity = PI.Quantity,
                    DateInventory = PI.DateInventory
                });
        }
        public IQueryable<DailyProductInventoryResponse> DailyProductInventoryResponseAsync(string? searchTerm)
        {
            var query = _context.ProductInventories
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(PI => PI.Product.Name.Contains(searchTerm));
            }

            return query
                .OrderByDescending(PI => PI.ID)
                .Select(PI => new DailyProductInventoryResponse
                {
                    ID = PI.ID,
                    ProductName = PI.Product.Name,
                    RemainingQuantity = PI.DailyConsumptions.Select(DC => DC.Quantity).FirstOrDefault() - PI.Quantity,
                    DateInventory = PI.DateInventory
                });
        }
    }
}
