using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;

namespace SMS_backend.Controllers
{
    public class ProductQueries
    {
        private readonly Db _context;
        public ProductQueries(Db context)
        {
            _context = context;
        }
        public async Task<List<Product>> ProductsList(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Product
                    .AsNoTracking()
                    .Where(p => p.Name.Contains(searchTerm) ||
                    p.Price.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm))
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
            else
            {
                return await _context.Product
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
        }
        public IQueryable<Product> PaginatedProducts(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Product
                    .AsNoTracking()
                    .Where(p => p.Name.Contains(searchTerm) ||
                    p.Price.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm))
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Product
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Product>> ActiveProductsList(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Product
                    .AsNoTracking()
                    .Where(p => p.RecordStatus == RecordStatus.Active && p.Name.Contains(searchTerm) ||
                    p.Price.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm))
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
            else
            {
                return await _context.Product
                    .AsNoTracking()
                    .Where(p => p.RecordStatus == RecordStatus.Active)
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
        }
        public IQueryable<Product> PaginatedActiveProducts(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Product
                    .AsNoTracking()
                    .Where(p => p.RecordStatus == RecordStatus.Active && p.Name.Contains(searchTerm) ||
                    p.Price.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm))
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Product
                    .AsNoTracking()
                    .Where(p => p.RecordStatus == RecordStatus.Active)
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.Id)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<Product?> GetProductByID(int id)
        {
            return await _context.Product
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product?> PatchProductByID(int id)
        {
            return await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
