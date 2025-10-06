using AutoMapper;
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
        Task<UserResponse> CreateUser(CreateUserRequest request);
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
        public async Task<List<UserResponse>> UsersList(string searchTerm)
        {
            var users = await _queries.UsersList(searchTerm);
            return _mapper.Map<List<UserResponse>>(users);
        }
        public async Task<Pagination<UserResponse>> PaginatedUsers(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedUsers(searchTerm);
            return await PaginationHelper.PaginateAndMap<User, UserResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.DateCreated = DateTimeHelper.GetPhilippineStandardTime();

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(user);
        }
    }
}
