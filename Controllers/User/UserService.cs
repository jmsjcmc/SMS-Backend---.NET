using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class UserService : IUserService
    {
        private readonly UserQuery _userQuery;
        private readonly JWTHelper _jwtHelper;
        private readonly Db _context;
        private readonly IMapper _mapper;
        public UserService(UserQuery userQuery, JWTHelper jwtHelper, Db context, IMapper mapper)
        {
            _userQuery = userQuery;
            _jwtHelper = jwtHelper;
            _context = context;
            _mapper = mapper;
        }
        public async Task<LogInResponse> LogInAsync(LogInRequest request)
        {
            var user = await _context.Users
                .Where(U => U.Username == request.Username &&
                U.RecordStatus == RecordStatus.Active)
                .Select(U => new
                {
                    U.ID,
                    U.Username,
                    U.Password,
                    Roles = U.UserRoles.Select(UR => UR.Role.Name).ToList()
                }).SingleOrDefaultAsync();

            if (user == null)
                throw new UnauthorizedAccessException("INVALID USERNAME OR PASSWORD");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new UnauthorizedAccessException("INVALID USERNAME OR PASSWORD");

            var accessToken = _jwtHelper.GenerateToken(user.ID, user.Username, user.Roles);
            return new LogInResponse
            {
                AccessToken = accessToken
            };
        }
        public async Task<UserOnlyResponse?> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal creator)
        {
            var newUser = _mapper.Map<User>(request);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            newUser.CreatorID = AuthUserHelper.GetUserID(creator);
            newUser.CreatedOn = DateTimeHelper.GetPhilippineStandardTime();
            newUser.RecordStatus = RecordStatus.Active;

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return await _userQuery.UserOnlyResponseByIDAsync(newUser.ID);
        }
        public async Task<UserOnlyResponse?> PatchUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal updater)
        {
            var query = await _userQuery.PatchUserByIDAsync(ID);

            _mapper.Map(request, query);
            query.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _context.SaveChangesAsync();

            var userLog = new UserLog
            {
                UserID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.UserLogs.AddAsync(userLog);
            await _context.SaveChangesAsync();

            return await _userQuery.UserOnlyResponseByIDAsync(query.ID);
        }
        public async Task<UserOnlyResponse?> PatchUserStatusByIDAsync(int ID, RecordStatus? recordStatus, ClaimsPrincipal updater)
        {
            var query = await _userQuery.PatchUserByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var userLog = new UserLog
            {
                UserID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.UserLogs.AddAsync(userLog);
            await _context.SaveChangesAsync();

            return await _userQuery.UserOnlyResponseByIDAsync(query.ID);
        }
        public async Task<UserOnlyResponse?> DeleteUserByIDAsync(int ID)
        {
            var query = await _userQuery.PatchUserByIDAsync(ID);

            _context.Users.Remove(query);
            await _context.SaveChangesAsync();

            return await _userQuery.UserOnlyResponseByIDAsync(ID);
        }
        public async Task<UserWithRoleResponse?> GetAuthenticatedUserDetailAsync(ClaimsPrincipal authenticated)
        {
            var userID = authenticated.Claims
                .Where(C => C.Type == "UserID")
                .Select(C => int.Parse(C.Value))
                .SingleOrDefault();

            return await _context.Users
                .Where(U => U.ID == userID &&
                U.RecordStatus == RecordStatus.Active)
                .Select(U => new UserWithRoleResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    Avatar = U.Avatar,
                    RecordStatus = U.RecordStatus,
                    Roles = U.UserRoles.Select(UR => UR.Role.Name).ToList()
                }).SingleOrDefaultAsync();

        }
        public async Task<UserOnlyResponse?> GetUserByIDAsync(int ID)
        {
            return await _userQuery.UserOnlyResponseByIDAsync(ID);
        }
        public async Task<Pagination<UserOnlyResponse>> GetPaginatedUsersAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _userQuery.UserOnlyResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<UserOnlyResponse>> GetListedUsersAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _userQuery.UserOnlyResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
