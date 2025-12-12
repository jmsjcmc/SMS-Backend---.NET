using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly Db _context;
        public CategoryQuery(Db context)
        {
            _context = context;
        }
        public async Task<Category?> PatchCategoryByIDAsync(int ID)
        {
            return await _context.Categories
                .SingleOrDefaultAsync(C => C.ID == ID);
        }
        public async Task<CategoryOnlyResponse?> CategoryOnlyResponseByIDAsync(int ID)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(C => C.ID == ID)
                .Select(C => new CategoryOnlyResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    RecordStatus = C.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<CategoryWithProductsResponse?> CategoryWithProductsResponseByIDAsync(int ID)
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(C => C.ID == ID)
                .Select(C => new CategoryWithProductsResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Products = C.Products.Select(P => new ProductOnlyResponse
                    {
                        ID = P.ID,
                        Name = P.Name,
                        RecordStatus = P.RecordStatus
                    }).ToList()
                }).SingleOrDefaultAsync();
        }
        public IQueryable<CategoryOnlyResponse> CategoryOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Categories
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(C => C.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(C => C.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(C => C.ID)
                .Select(C => new CategoryOnlyResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    RecordStatus = C.RecordStatus
                });
        }
        public IQueryable<CategoryWithProductsResponse> CategoryWithProductsResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Categories
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(C => C.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(C => C.RecordStatus == recordStatus.Value);
            }

            return query
                .OrderByDescending(C => C.ID)
                .Select(C => new CategoryWithProductsResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Products = C.Products.Select(P => new ProductOnlyResponse
                    {
                        ID = P.ID,
                        Name = P.Name,
                        RecordStatus = P.RecordStatus
                    }).ToList()
                });
        }
    }
}
