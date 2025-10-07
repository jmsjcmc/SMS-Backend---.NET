using AutoMapper;
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
        Task<List<DepartmentResponse>> DepartmentsList(string searchTerm);
        Task<Pagination<DepartmentResponse>> PaginatedDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<DepartmentResponse> GetDepartmentByID(int id);
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
        public async Task<List<DepartmentResponse>> ActiveDepartmentsList(string searchTerm)
        {
            var departments = await _queries.ActiveDepartmentsList(searchTerm);
            return _mapper.Map<List<DepartmentResponse>>(departments);
        }
        public async Task<Pagination<DepartmentResponse>> PaginatedActiveDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveDepartments(searchTerm);
            return await PaginationHelper.PaginateAndMap<Department, DepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<List<DepartmentResponse>> DepartmentsList(string searchTerm)
        {
            var departments = await _queries.DepartmentsList(searchTerm);
            return _mapper.Map<List<DepartmentResponse>>(departments);
        }
        public async Task<Pagination<DepartmentResponse>> PaginatedDepartments(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedDepartments(searchTerm);
            return await PaginationHelper.PaginateAndMap<Department, DepartmentResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<DepartmentResponse> GetDepartmentByID(int id)
        {
            var department = await _queries.GetDepartmentByID(id);
            return _mapper.Map<DepartmentResponse>(department);
        }
        public async Task<DepartmentResponse> CreateDepartment(string departmentName)
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
        public async Task<DepartmentResponse> UpdateDepartmentByID(string departmentName, int id)
        {
            var department = await _queries.PatchDepartmentByID(id);

            department.Name = departmentName;
            department.DateUpdated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponse>(department);
        }
        public async Task<DepartmentResponse> RemoveDepartmentByID(int id)
        {
            var department = await _queries.PatchDepartmentByID(id);

            department.RecordStatus = department.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponse>(department);
        }
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
        
    }
    public class PositionService : PositionInterface
    {

    }
}
