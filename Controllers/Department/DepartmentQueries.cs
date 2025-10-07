using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;

namespace SMS_backend.Controllers
{
    public class DepartmentQueries
    {
        private readonly Db _context;
        public DepartmentQueries(Db context)
        {
            _context = context;
        }
        public async Task<List<Department>> ActiveDepartmentsList(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm) && d.RecordStatus == RecordStatus.Active)
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .ToListAsync();
            }
            else
            {
                return await _context.Department
                    .AsNoTracking()
                    .Where(d => d.RecordStatus == RecordStatus.Active)
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .ToListAsync();
            }
        }
        public IQueryable<Department> PaginatedActiveDepartments(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm) && 
                    d.RecordStatus == RecordStatus.Active)
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Where(d => d.RecordStatus == RecordStatus.Active)
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Department>> DepartmentsList(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .ToListAsync();
            } else
            {
                return await _context.Department
                    .AsNoTracking()
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .ToListAsync();
            }
        }
        public IQueryable<Department> PaginatedDepartments(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.Id)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<Department?> GetDepartmentByID(int id)
        {
            return await _context.Department
                .AsNoTracking()
                .Include(d => d.Position)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Department?> PatchDepartmentByID(int id)
        {
            return await _context.Department
                .Include(d => d.Position)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
    public class PositionQueries
    {
        private readonly Db _context;
        public PositionQueries(Db context)
        {
            _context = context;
        }

    }
}
