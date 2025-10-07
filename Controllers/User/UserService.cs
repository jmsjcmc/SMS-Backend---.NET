using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    public interface UserInterface
    {
        Task<List<UserResponse>> UsersList(string searchTerm);
        Task<Pagination<UserResponse>> PaginatedUsers(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<UserResponse>> ActiveUsersList(string searchTerm);
        Task<Pagination<UserResponse>> PaginatedActiveUsers(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<UserResponse> GetUserByID(Guid id);
        Task<UserResponse> CreateUser(CreateUserRequest request);
        Task<UserResponse> UpdateUserByID(UpdateUserRequest request, Guid id);
        Task<UserResponse> RemoveUserByID(Guid id);
        Task<UserResponse> DeleteUserByID(Guid id);
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
        public async Task<List<UserResponse>> ActiveUsersList(string searchTerm)
        {
            var users = await _queries.ActiveUsersList(searchTerm);
            return _mapper.Map<List<UserResponse>>(users);
        }
        // [HttpGet("users/active-paginated")]
        public async Task<Pagination<UserResponse>> PaginatedActiveUsers(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveUsers(searchTerm);
            return await PaginationHelper.PaginateAndMap<User, UserResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("users/list")]
        public async Task<List<UserResponse>> UsersList(string searchTerm)
        {
            var users = await _queries.UsersList(searchTerm);
            return _mapper.Map<List<UserResponse>>(users);
        }
        // [HttpGet("users/paginated")]
        public async Task<Pagination<UserResponse>> PaginatedUsers(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedUsers(searchTerm);
            return await PaginationHelper.PaginateAndMap<User, UserResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("user/{id}")]
        public async Task<UserResponse> GetUserByID(Guid id)
        {
            var user = await _queries.GetUserByID(id);
            return _mapper.Map<UserResponse>(user);
        }
        // [HttpPost("user/create")]
        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            if (await _context.User.AnyAsync(u => u.Username == request.Username))
            {
                throw new ArgumentException("Username exist");
            }
            else
            {
                var user = _mapper.Map<User>(request);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.DateCreated = DateTimeHelper.GetPhilippineStandardTime();
                user.RecordStatus = RecordStatus.Active;

                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return _mapper.Map<UserResponse>(user);
            }
        }
        // [HttpPatch("user/update/{id}")]
        public async Task<UserResponse> UpdateUserByID(UpdateUserRequest request, Guid id)
        {
            var user = await _queries.PatchUserByID(id);

            _mapper.Map(request, user);
            user.DateUpdated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(user);
        }
        // [HttpPatch("user/toggle-status/{id}")]
        public async Task<UserResponse> RemoveUserByID(Guid id)
        {
            var user = await _queries.PatchUserByID(id);

            user.RecordStatus = user.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(user);
        }
        // [HttpDelete("user/delete/{id}")]
        public async Task<UserResponse> DeleteUserByID(Guid id)
        {
            var user = await _queries.PatchUserByID(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(user);
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
        Task<RoleResponse> GetRoleByID(Guid id);
        Task<RoleResponse> CreateRole(string roleName);
        Task<RoleResponse> UpdateRoleByID(string roleName, Guid id);
        Task<RoleResponse> RemoveRoleByID(Guid id);
    }
}
