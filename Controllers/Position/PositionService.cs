using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class PositionService : IPositionService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;
        private readonly PositionQuery _positionQuery;
        public PositionService(Db context, IMapper mapper, PositionQuery positionQuery)
        {
            _context = context;
            _mapper = mapper;
            _positionQuery = positionQuery;
        }
        public async Task<PositionOnlyResponse?> CreatePositionAsync(CreatePositionRequest request, ClaimsPrincipal creator)
        {
            var newPosition = _mapper.Map<Position>(request);
            newPosition.CreatorID = AuthUserHelper.GetUserID(creator);
            newPosition.CreatedOn = DateTimeHelper.GetPhilippineStandardTime();
            newPosition.RecordStatus = RecordStatus.Active;

            await _context.Positions.AddAsync(newPosition);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionOnlyResponseByIDAsync(newPosition.ID);
        }
        public async Task<PositionWithDepartmentResponse?> PatchPositionByIDAsync(int ID, UpdatePositionRequest request, ClaimsPrincipal updater)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.PositionLogs.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse?> PatchPositionStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.PositionLogs.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse?> AddPositionToDepartmentByIDAsync(int positionID, int departmentID, ClaimsPrincipal updater)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(positionID);

            query.DepartmentID = departmentID;

            await _context.SaveChangesAsync();

            var positionLog = new PositionLog
            {
                PositionID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.PositionLogs.AddAsync(positionLog);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse?> DeletePositionByIDAsync(int ID)
        {
            var query = await _positionQuery.PatchPositionByIDAsync(ID);

            _context.Positions.Remove(query);
            await _context.SaveChangesAsync();

            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(query.ID);
        }
        public async Task<PositionWithDepartmentResponse?> GetPositionByIDAsync(int ID)
        {
            return await _positionQuery.PositionWithDepartmentResponseByIDAsync(ID);
        }
        public async Task<Pagination<PositionOnlyResponse>> GetPaginatedPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _positionQuery.PositionOnlyResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<Pagination<PositionWithDepartmentResponse>> GetPaginatedPositionsWithDepartmentAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _positionQuery.PositionWithDepartmentResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<PositionOnlyResponse>> GetListedPositionsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _positionQuery.PositionOnlyResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
        public async Task<List<PositionWithDepartmentResponse>> GetListedPositionsWithDepartmentAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _positionQuery.PositionWithDepartmentResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
