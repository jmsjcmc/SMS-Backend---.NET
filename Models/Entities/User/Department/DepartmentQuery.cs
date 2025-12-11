using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class DepartmentQuery : IDeparmentQuery
    {
        private readonly Db _context;
        public DepartmentQuery(Db context)
        {
            _context = context;
        }
        public async Task<Department?> PatchDepartmentByIDAsync(int ID)
        {
            return await _context.Departments
                .SingleOrDefaultAsync(D => D.ID == ID);
        }
        public async Task<DepartmentOnlyResponse?> DepartmentOnlyResponseByIDAsync(int ID)
        {
            return await _context.Departments
                .AsNoTracking()
                .Where(D => D.ID == ID)
                .Select(D => new DepartmentOnlyResponse
                {
                    ID = D.ID,
                    Name = D.Name,
                    Description = D.Description,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    RecordStatus = D.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<DepartmentWithPositionsResponse?> DepartmentWithPositionsResponseByIDAsync(int ID)
        {
            return await _context.Departments
                .AsNoTracking()
                .Where(D => D.ID == ID)
                .Select(D => new DepartmentWithPositionsResponse
                {
                    ID = D.ID,
                    Name = D.Name,
                    Description = D.Description,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    RecordStatus = D.RecordStatus,
                    Positions = D.Positions.Select(P => new PositionOnlyResponse
                    {
                        ID = P.ID,
                        Name = P.Name,
                        Description = P.Description,
                        CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                        CreatedOn = P.CreatedOn,
                        RecordStatus = P.RecordStatus,
                    }).ToList()
                }).SingleOrDefaultAsync();
        }
        public IQueryable<DepartmentOnlyResponse> DepartmentOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Departments
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(D => D.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(D => D.RecordStatus == recordStatus);
            }

            return query
                .OrderByDescending(D => D.ID)
                .Select(D => new DepartmentOnlyResponse
                {
                    ID = D.ID,
                    Name = D.Name,
                    Description = D.Description,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    RecordStatus = D.RecordStatus
                });
        }
        public IQueryable<DepartmentWithPositionsResponse> DepartmentWithPositionsResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Departments
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(D => D.Name.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(D => D.RecordStatus == recordStatus);
            }

            return query
                .OrderByDescending(D => D.ID)
                .Select(D => new DepartmentWithPositionsResponse
                {
                    ID = D.ID,
                    Name = D.Name,
                    Description = D.Description,
                    CreatorFullName = $"{D.Creator.FirstName} {D.Creator.LastName}",
                    CreatedOn = D.CreatedOn,
                    RecordStatus = D.RecordStatus,
                    Positions = D.Positions.Select(P => new PositionOnlyResponse
                    {
                        ID = P.ID,
                        Name = P.Name,
                        Description = P.Description,
                        CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                        CreatedOn = P.CreatedOn,
                        RecordStatus = P.RecordStatus,
                    }).ToList()
                });
        }
    }
}
