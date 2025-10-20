using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    public interface DepartmentInterface
    {
        Task<List<DepartmentResponse>> ActiveDepartmentsList(string searchTerm);
        Task<Pagination<DepartmentResponse>> PaginatedActiveDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<DepartmentWithPositionResponse>> DepartmentWithPositionsList(string searchTerm);
        Task<Pagination<DepartmentWithPositionResponse>> PaginatedDepartmentWithPositions(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<DepartmentResponse>> DepartmentsList(string searchTerm);
        Task<Pagination<DepartmentResponse>> PaginatedDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<int> AllDepartmentsCount();
        Task<int> ActiveDepartmentsCount();
        Task<DepartmentResponse> GetDepartmentByID(int id);
        Task<DepartmentWithPositionResponse> GetDepartmentWithPositionsByID(int id);
        Task<DepartmentResponse> CreateDepartment(string departmentName);
        Task<DepartmentResponse> UpdateDepartmentByID(string departmentName, int id);
        Task<DepartmentResponse> RemoveDepartmentByID(int id);
        Task<DepartmentResponse> DeleteDepartmentByID(int id);
    }
    public class DepartmentService : DepartmentInterface
    {
        private readonly DepartmentQueries _queries;
        private readonly IMapper _mapper;
        private readonly Db _context;
        public DepartmentService(DepartmentQueries queries, IMapper mapper, Db context)
        {
            _queries = queries;
            _mapper = mapper;
            _context = context;
        }
        // [HttpGet("departments/active-list")]
        public async Task<List<DepartmentResponse>> ActiveDepartmentsList(string searchTerm)
        {
            var departments = await _queries.ActiveDepartmentsList(searchTerm);
            return _mapper.Map<List<DepartmentResponse>>(departments);
        }
        // [HttpGet("departments/active-paginated")]
        public async Task<Pagination<DepartmentResponse>> PaginatedActiveDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveDepartments(searchTerm);
            return await PaginationHelper.PaginateAndMap<Department, DepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("department/list-with-positions")]
        public async Task<List<DepartmentWithPositionResponse>> DepartmentWithPositionsList(string searchTerm)
        {
            var department = await _queries.ActiveDepartmentsList(searchTerm);
            return _mapper.Map<List<DepartmentWithPositionResponse>>(department);
        }
        // [HttpGet("departments/paginated-with-positions")]
        public async Task<Pagination<DepartmentWithPositionResponse>> PaginatedDepartmentWithPositions(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveDepartments(searchTerm);
            return await PaginationHelper.PaginateAndMap<Department, DepartmentWithPositionResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("departments/list")]
        public async Task<List<DepartmentResponse>> DepartmentsList(string searchTerm)
        {
            var departments = await _queries.DepartmentsList(searchTerm);
            return _mapper.Map<List<DepartmentResponse>>(departments);
        }
        // [HttpGet("departments/paginated")]
        public async Task<Pagination<DepartmentResponse>> PaginatedDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedDepartments(searchTerm);
            return await PaginationHelper.PaginateAndMap<Department, DepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("departments/count")] - Total
        public async Task<int> AllDepartmentsCount()
        {
            return await _context.Department
                .AsNoTracking()
                .CountAsync();
        }
        // [HttpGet("departments/count")] - Active
        public async Task<int> ActiveDepartmentsCount()
        {
            return await _context.Department
                .AsNoTracking()
                .Where(d => d.RecordStatus == RecordStatus.Active)
                .CountAsync();
        }
        // [HttpGet("department/{id}")]
        public async Task<DepartmentResponse> GetDepartmentByID(int id)
        {
            var department = await _queries.GetDepartmentByID(id);
            return _mapper.Map<DepartmentResponse>(department);
        }
        // [HttpGet("department/with-positions/{id}")]
        public async Task<DepartmentWithPositionResponse> GetDepartmentWithPositionsByID(int id)
        {
            var department = await _queries.GetDepartmentByID(id);
            return _mapper.Map<DepartmentWithPositionResponse>(department);
        }
        // [HttpPost("department/create")]
        public async Task<DepartmentResponse> CreateDepartment(string departmentName)
        {
            if (await _context.Department.AnyAsync(d => d.Name == departmentName))
            {
                throw new ArgumentException("Department Name exist.");
            } else
            {
                var department = new Department
                {
                    Name = departmentName,
                    RecordStatus = RecordStatus.Active,
                    DateCreated = DateTimeHelper.GetPhilippineStandardTime()
                };

                await _context.Department.AddAsync(department);
                await _context.SaveChangesAsync();
                return _mapper.Map<DepartmentResponse>(department);
            }
        }
        // [HttpPatch("department/update/{id}")]
        public async Task<DepartmentResponse> UpdateDepartmentByID(string departmentName, int id)
        {
            var department = await _queries.PatchDepartmentByID(id);

            department.Name = departmentName;
            department.DateUpdated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponse>(department);
        }
        // [HttpPatch("department/toggle-status/{id}")]
        public async Task<DepartmentResponse> RemoveDepartmentByID(int id)
        {
            var department = await _queries.PatchDepartmentByID(id);

            department.RecordStatus = department.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponse>(department);
        }
        // [HttpDelete("department/delete/{id}")]
        public async Task<DepartmentResponse> DeleteDepartmentByID(int id)
        {
            var department = await _queries.PatchDepartmentByID(id);
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponse>(department);
        }
    }
    public interface PositionInterface
    {
        Task<List<PositionResponse>> ActivePositionsList(string searchTerm);
        Task<Pagination<PositionResponse>> PaginatedActivePositions(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<PositionWithDepartmentResponse>> PositionWithDepartmentList(string searchTerm);
        Task<Pagination<PositionWithDepartmentResponse>> PaginatedPositionsWithDepartment(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<PositionResponse>> PositionsList(string searchTerm);
        Task<Pagination<PositionResponse>> PaginatedPositions(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<int> AllPositionsCount();
        Task<int> ActivePositionsCount();
        Task<PositionResponse> GetPositionByID(int id);
        Task<PositionResponse> CreatePosition(CreatePositionRequest request);
        Task<PositionResponse> UpdatePositionByID(UpdatePositionRequest request, int id);
        Task<PositionResponse> RemovePositionByID(int id);
        Task<PositionResponse> DeletePositionByID(int id);
    }
    public class PositionService : PositionInterface
    {
        private readonly Db _context;
        private readonly PositionQueries _queries;
        private readonly IMapper _mapper;
        public PositionService(Db context, PositionQueries queries, IMapper mapper)
        {
            _context = context;
            _queries = queries;
            _mapper = mapper;
        }
        // [HttpGet("positions/active-list")]
        public async Task<List<PositionResponse>> ActivePositionsList(string searchTerm)
        {
            var positions = await _queries.ActivePositionsList(searchTerm);
            return _mapper.Map<List<PositionResponse>>(positions);
        }
        // [HttpGet("positions/active-paginated")]
        public async Task<Pagination<PositionResponse>> PaginatedActivePositions(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActivePositions(searchTerm);
            return await PaginationHelper.PaginateAndMap<Position, PositionResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("positions/list-with-department")]
        public async Task<List<PositionWithDepartmentResponse>> PositionWithDepartmentList(string searchTerm)
        {
            var positions = await _queries.ActivePositionsList(searchTerm);
            return _mapper.Map<List<PositionWithDepartmentResponse>>(positions);
        }
        // [HttpGet("positions/paginated-with-departments")]
        public async Task<Pagination<PositionWithDepartmentResponse>> PaginatedPositionsWithDepartment(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActivePositions(searchTerm);
            return await PaginationHelper.PaginateAndMap<Position, PositionWithDepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("positions/list")]
        public async Task<List<PositionResponse>> PositionsList(string searchTerm)
        {
            var positions = await _queries.PositionsList(searchTerm);
            return _mapper.Map<List<PositionResponse>>(positions);
        }
        // [HttpGet("positions/paginated")]
        public async Task<Pagination<PositionResponse>> PaginatedPositions(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedPositions(searchTerm);
            return await PaginationHelper.PaginateAndMap<Position, PositionResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("positions/count")] - Total
        public async Task<int> AllPositionsCount()
        {
            return await _context.Position
                .AsNoTracking()
                .CountAsync();
        }
        // [HttpGet("positions/count")] - Active
        public async Task<int> ActivePositionsCount()
        {
            return await _context.Position
                .AsNoTracking()
                .Where(p => p.RecordStatus == RecordStatus.Active)
                .CountAsync();
        }
        // [HttpGet("position/{id}")]
        public async Task<PositionResponse> GetPositionByID(int id)
        {
            var position = await _queries.GetPositionByID(id);
            return _mapper.Map<PositionResponse>(position);
        }
        // [HttpPost("position/create")]
        public async Task<PositionResponse> CreatePosition(CreatePositionRequest request)
        {
            if (await _context.Position.AnyAsync(p => p.Name == request.Name))
            {
                throw new ArgumentException("Position Name exist");
            } else
            {
                var position = _mapper.Map<Position>(request);
                position.RecordStatus = RecordStatus.Active;
                position.DateCreated = DateTimeHelper.GetPhilippineStandardTime();

                await _context.Position.AddAsync(position);
                await _context.SaveChangesAsync();

                return _mapper.Map<PositionResponse>(position);
            }
        }
        // [HttpPatch("position/update/{id}")]
        public async Task<PositionResponse> UpdatePositionByID(UpdatePositionRequest request, int id)
        {
            var position = await _queries.PatchPositionByID(id);

            _mapper.Map(position, request);
            position.DateUpdated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.SaveChangesAsync();
            return _mapper.Map<PositionResponse>(position);
        }
        // [HttpPatch("position/toggle-status/{id}")]
        public async Task<PositionResponse> RemovePositionByID(int id)
        {
            var position = await _queries.PatchPositionByID(id);
            position.RecordStatus = position.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();
            return _mapper.Map<PositionResponse>(position);
        }
        // [HttpDelete("position/delete/{id}")]
        public async Task<PositionResponse> DeletePositionByID(int id)
        {
            var position = await _queries.PatchPositionByID(id);

            _context.Position.Remove(position);
            await _context.SaveChangesAsync();

            return _mapper.Map<PositionResponse>(position);
        }
    }
}
