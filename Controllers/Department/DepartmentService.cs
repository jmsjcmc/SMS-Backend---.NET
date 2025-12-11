using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentQuery _departmentQuery;
        private readonly Db _context;
        private readonly IMapper _mapper;
        public DepartmentService(DepartmentQuery departmentQuery, Db context, IMapper mapper)
        {
            _departmentQuery = departmentQuery;
            _context = context;
            _mapper = mapper;
        }
        public async Task<DepartmentOnlyResponse?> CreateDepartmentAsync(CreateDepartmentRequest request, ClaimsPrincipal creator)
        {
            var newDepartment = _mapper.Map<Department>(request);
            newDepartment.CreatorID = AuthUserHelper.GetUserID(creator);
            newDepartment.CreatedOn = DateTimeHelper.GetPhilippineStandardTime();
            newDepartment.RecordStatus = RecordStatus.Active;

            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();

            return await _departmentQuery.DepartmentOnlyResponseByIDAsync(newDepartment.ID);
        }
        public async Task<DepartmentWithPositionsResponse?> PatchDepartmentByIDAsync(int ID, UpdateDepartmentRequest request, ClaimsPrincipal updater)
        {
            var query = await _departmentQuery.PatchDepartmentByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var departmentLog = new DepartmentLog
            {
                DepartmentID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.DepartmentLogs.AddAsync(departmentLog);
            await _context.SaveChangesAsync();

            return await _departmentQuery.DepartmentWithPositionsResponseByIDAsync(query.ID);
        }
        public async Task<DepartmentWithPositionsResponse?> PatchDepartmentStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater)
        {
            var query = await _departmentQuery.PatchDepartmentByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var departmentLog = new DepartmentLog
            {
                DepartmentID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.DepartmentLogs.AddAsync(departmentLog);
            await _context.SaveChangesAsync();

            return await _departmentQuery.DepartmentWithPositionsResponseByIDAsync(query.ID);
        }
        public async Task<DepartmentWithPositionsResponse?> DeleteDepartmentByIDAsync(int ID)
        {
            var query = await _departmentQuery.PatchDepartmentByIDAsync(ID);

            _context.Departments.Remove(query);
            await _context.SaveChangesAsync();

            return await _departmentQuery.DepartmentWithPositionsResponseByIDAsync(query.ID);
        }
        public async Task<DepartmentWithPositionsResponse?> GetDepartmentByIDAsync(int ID)
        {
            return await _departmentQuery.DepartmentWithPositionsResponseByIDAsync(ID);
        }
        public async Task<Pagination<DepartmentWithPositionsResponse>> GetPaginatedDepartmentsWithPositionsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _departmentQuery.DepartmentWithPositionsResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<Pagination<DepartmentOnlyResponse>> GetPaginatedDepartmentsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _departmentQuery.DepartmentOnlyResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<DepartmentWithPositionsResponse>> GetListedDepartmentsWithPositionsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _departmentQuery.DepartmentWithPositionsResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
        public async Task<List<DepartmentOnlyResponse>> GetListedDepartmentsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _departmentQuery.DepartmentOnlyResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
