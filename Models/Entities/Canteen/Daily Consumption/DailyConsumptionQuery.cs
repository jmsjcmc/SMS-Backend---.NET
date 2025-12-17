using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class DailyConsumptionQuery : IDailyConsumptionQuery
    {
        private readonly Db _context;
        public DailyConsumptionQuery(Db context)
        {
            _context = context;
        }
        public async Task<DailyConsumption?> PatchDailyConsumptionByIDAsync(int ID)
        {
            return await _context.DailyConsumptions
                .SingleOrDefaultAsync(DC => DC.ID == ID);
        }
        public async Task<DailyConsumptionOnlyResponse?> DailyConsumptionOnlyResponseByIDAsync(int ID)
        {
            return await _context.DailyConsumptions
                .AsNoTracking()
                .Where(DC => DC.ID == ID)
                .Select(DC => new DailyConsumptionOnlyResponse
                {
                    ID = DC.ID,
                    ProductInventoryID = DC.ProductInventoryID,
                    ProductName = DC.Product.Name,
                    Quantity = DC.Quantity,
                    ProductConsumptionStatus = DC.ProductConsumptionStatus,
                }).SingleOrDefaultAsync();
        }
        public IQueryable<DailyConsumptionOnlyResponse> DailyConsumptionOnlyResponseAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus)
        {
            var query = _context.DailyConsumptions
                .AsNoTracking()
                .AsQueryable();

            return query
                .OrderByDescending(DC => DC.ID)
                .Select(DC => new DailyConsumptionOnlyResponse
                {
                    ID = DC.ID,
                    ProductInventoryID = DC.ProductInventoryID,
                    ProductName = DC.Product.Name,
                    Quantity = DC.Quantity,
                    ProductConsumptionStatus = DC.ProductConsumptionStatus,
                });
        }
    }
}
