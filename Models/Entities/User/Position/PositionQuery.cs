using Microsoft.EntityFrameworkCore;
using SMS_backend.Controllers;

namespace SMS_backend.Models
{
    public class PositionQuery : IPositionQuery
    {
        private readonly Db _context;
        public PositionQuery(Db context)
        {
            _context = context;
        }
        public async Task<Position?> PatchPositionByIDAsync(int ID)
        {
            return await _context.Positions
                .SingleOrDefaultAsync(P => P.ID == ID);
        }
        public async Task<PositionOnlyResponse?> PositionOnlyResponseByIDAsync(int ID)
        {
            return await _context.Positions
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new PositionOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    Description = P.Description,
                    CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<PositionWithDepartmentResponse?> PositionWithDepartmentResponseByIDAsync(int ID)
        {
            return await _context.Positions
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new PositionWithDepartmentResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    Description = P.Description,
                    CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus,
                    DepartmentID = P.DepartmentID,
                    DepartmentName = P.Department.Name
                }).SingleOrDefaultAsync();
        }
        public IQueryable<PositionOnlyResponse> PositionOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Positions
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
                .Select(P => new PositionOnlyResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    Description = P.Description,
                    CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus
                });
        }
        public IQueryable<PositionWithDepartmentResponse> PositionWithDepartmentResponseAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var query = _context.Positions
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
                .Select(P => new PositionWithDepartmentResponse
                {
                    ID = P.ID,
                    Name = P.Name,
                    Description = P.Description,
                    CreatorFullName = $"{P.Creator.FirstName} {P.Creator.LastName}",
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus,
                    DepartmentID = P.DepartmentID,
                    DepartmentName = P.Department.Name
                });
        }
    }
}
