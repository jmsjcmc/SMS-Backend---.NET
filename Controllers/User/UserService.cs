using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    public interface UserInterface
    {
        Task<List<UserWithPositionAndRoleResponse>> UsersList(string? searchTerm);
        Task<Pagination<UserWithPositionAndRoleResponse>> PaginatedUsers(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<UserWithPositionAndRoleResponse>> ActiveUsersList(string? searchTerm);
        Task<Pagination<UserWithPositionAndRoleResponse>> PaginatedActiveUsers(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<UserWithPositionAndRoleResponse> GetUserByID(int id);
        Task<UserWithPositionAndRoleResponse> CreateUser(CreateUserRequest request);
        Task<UserWithPositionAndRoleResponse> UpdateUserByID(UpdateUserRequest request, int id);
        Task<UserWithPositionAndRoleResponse> RemoveUserByID(int id);
        Task<UserWithPositionAndRoleResponse> DeleteUserByID(int id);
    }
    public class UserService : UserInterface
    {
        private readonly IMapper _mapper;
        private readonly Db _context;
        private readonly UserQueries _queries;
        public UserService(IMapper mapper, Db context, UserQueries queries)
        {
            _mapper = mapper;
            _context = context;
            _queries = queries;
        }
        // [HttpGet("users/active-list")]
        public async Task<List<UserWithPositionAndRoleResponse>> ActiveUsersList(string? searchTerm)
        {
            var users = await _queries.ActiveUsersList(searchTerm);
            return _mapper.Map<List<UserWithPositionAndRoleResponse>>(users);
        }
        // [HttpGet("users/active-paginated")]
        public async Task<Pagination<UserWithPositionAndRoleResponse>> PaginatedActiveUsers(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveUsers(searchTerm);
            return await PaginationHelper.PaginateAndMap<User, UserWithPositionAndRoleResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("users/list")]
        public async Task<List<UserWithPositionAndRoleResponse>> UsersList(string? searchTerm)
        {
            var users = await _queries.UsersList(searchTerm);
            return _mapper.Map<List<UserWithPositionAndRoleResponse>>(users);
        }
        // [HttpGet("users/paginated")]
        public async Task<Pagination<UserWithPositionAndRoleResponse>> PaginatedUsers(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedUsers(searchTerm);
            return await PaginationHelper.PaginateAndMap<User, UserWithPositionAndRoleResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("user/{id}")]
        public async Task<UserWithPositionAndRoleResponse> GetUserByID(int id)
        {
            var user = await _queries.GetUserByID(id);
            return _mapper.Map<UserWithPositionAndRoleResponse>(user);
        }
        // [HttpPost("user/create")]
        public async Task<UserWithPositionAndRoleResponse> CreateUser(CreateUserRequest request)
        {
            if (await _context.User.AnyAsync(u => u.Username == request.Username))
            {
                throw new ArgumentException("Username exist");
            }
            else
            {
                var positionExist = await _context.Position.AnyAsync(p => p.Id == request.PositionId);

                if (!positionExist)
                    throw new Exception("Position ID did not exist");

                var roleExist = await _context.Role
                    .Where(r => request.RoleId.Contains(r.Id))
                    .Select(r => r.Id)
                    .ToListAsync();

                if (roleExist.Count != request.RoleId.Count)
                    throw new Exception("One or more Role IDs are not available");

                var user = _mapper.Map<User>(request);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.DateCreated = DateTimeHelper.GetPhilippineStandardTime();
                user.RecordStatus = RecordStatus.Active;

                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return _mapper.Map<UserWithPositionAndRoleResponse>(user);
            }
        }
        // [HttpPatch("user/update/{id}")]
        public async Task<UserWithPositionAndRoleResponse> UpdateUserByID(UpdateUserRequest request, int id)
        {
            var user = await _queries.PatchUserByID(id);

            _mapper.Map(request, user);
            user.DateUpdated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithPositionAndRoleResponse>(user);
        }
        // [HttpPatch("user/toggle-status/{id}")]
        public async Task<UserWithPositionAndRoleResponse> RemoveUserByID(int id)
        {
            var user = await _queries.PatchUserByID(id);

            user.RecordStatus = user.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithPositionAndRoleResponse>(user);
        }
        // [HttpDelete("user/delete/{id}")]
        public async Task<UserWithPositionAndRoleResponse> DeleteUserByID(int id)
        {
            var user = await _queries.PatchUserByID(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithPositionAndRoleResponse>(user);
        }
    }
    public interface RoleInterface
    {
        Task<List<RoleResponse>> RolesList(string searchTerm);
        Task<Pagination<RoleResponse>> PaginatedRoles(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<RoleResponse>> ActiveRolesList(string searchTerm);
        Task<Pagination<RoleResponse>> PaginatedActiveRoles(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<RoleResponse> GetRoleByID(int id);
        Task<RoleResponse> CreateRole(string roleName);
        Task<RoleResponse> UpdateRoleByID(string roleName, int id);
        Task<RoleResponse> RemoveRoleByID(int id);
        Task<RoleResponse> DeletRoleByID(int id);
    }
    public class RoleService : RoleInterface
    {
        private readonly Db _context;
        private readonly RoleQueries _queries;
        private readonly IMapper _mapper;
        public RoleService(Db context, RoleQueries queries, IMapper mapper)
        {
            _context = context;
            _queries = queries;
            _mapper = mapper;
        }
        // [HttpGet("roles/list")]
        public async Task<List<RoleResponse>> RolesList(string searchTerm)
        {
            var roles = await _queries.RolesList(searchTerm);
            return _mapper.Map<List<RoleResponse>>(roles);
        }
        // [HttpGet("roles/paginated")]
        public async Task<Pagination<RoleResponse>> PaginatedRoles(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedRoles(searchTerm);

            return await PaginationHelper.PaginateAndMap<Role, RoleResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("roles/active-list")]
        public async Task<List<RoleResponse>> ActiveRolesList(string searchTerm)
        {
            var roles = await _queries.ActiveRolesList(searchTerm);
            return _mapper.Map<List<RoleResponse>>(roles);
        }
        // [HttpGet("roles/active-paginated")]
        public async Task<Pagination<RoleResponse>> PaginatedActiveRoles(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveRoles(searchTerm);
            return await PaginationHelper.PaginateAndMap<Role, RoleResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("role/{id}")]
        public async Task<RoleResponse> GetRoleByID(int id)
        {
            var role = await _queries.GetRoleByID(id);
            return _mapper.Map<RoleResponse>(role);
        }
        // [HttpPost("role/create")]
        public async Task<RoleResponse> CreateRole(string roleName)
        {
            if (await _context.Role.AnyAsync(r => r.Name == roleName))
            {
                throw new ArgumentException("Role Name exist");
            }
            else
            {
                var role = new Role
                {
                    Name = roleName,
                    RecordStatus = RecordStatus.Active
                };

                await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoleResponse>(role);
            }
        }
        // [HttpPatch("role/update/{id}")]
        public async Task<RoleResponse> UpdateRoleByID(string roleName, int id)
        {
            var role = await _queries.PatchRoleByID(id);

            role.Name = roleName;

            await _context.SaveChangesAsync();
            return _mapper.Map<RoleResponse>(role);
        }
        // [HttpPatch("role/toggle-status/{id}")]
        public async Task<RoleResponse> RemoveRoleByID(int id)
        {
            var role = await _queries.PatchRoleByID(id);

            role.RecordStatus = role.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();

            return _mapper.Map<RoleResponse>(role);
        }
        // [HttpDelete("role/delete/{id}")]
        public async Task<RoleResponse> DeletRoleByID(int id)
        {
            var role = await _queries.PatchRoleByID(id);

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoleResponse>(role);
        }
    }
}
