using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class ProductQuery : IProductQuery
    {
        private readonly Db _context;
        public ProductQuery(Db context)
        {
            _context = context;
        }
        public async Task<Product?> PatchProductByIDAsync(int ID)
        {
            return await _context.Products
                .SingleOrDefaultAsync(P => P.ID == ID);
        }
        public async Task<ProductOnlyResponse?> ProductOnlyResponseByIDAsync(int ID)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new ProductOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<ProductWithCategoryResponse?> ProductWithCategoryResponseByIDAsync(int ID)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new ProductWithCategoryResponse
                {
                    ID = P.ID,
                    CategoryID = P.CategoryID,
                    CategoryName = P.Category.Name,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<ProductOnlyResponse> ProductOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(P => P.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(P => P.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(P => P.ID)
                .Select(P => new ProductOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                });
        }
        public IQueryable<ProductWithCategoryResponse> ProductWithCategoryResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Products
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(P => P.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(P => P.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(P => P.ID)
                .Select(P => new ProductWithCategoryResponse
                {
                    ID = P.ID,
                    CategoryID = P.CategoryID,
                    CategoryName = P.Category.Name,
                    Name = P.Name,
                    RecordStatus = P.RecordStatus
                });
        }
    }
}
