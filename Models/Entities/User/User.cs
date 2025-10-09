using AutoMapper;

namespace SMS_backend.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } = null;
        public RecordStatus RecordStatus { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.UserRole, o => o.MapFrom(s => s.RoleId.Select(roleID => new UserRole
                {
                    RoleId = roleID
                })));

            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());

            CreateMap<User, UserResponse>();

            CreateMap<User, UserWithPositionAndRoleResponse>()
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position))
                .ForMember(d => d.Role, o => o.MapFrom(s => s.UserRole.Select(ur => ur.Role)));
        }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleResponse>();
        }
    }
    public class UserRole
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public RecordStatus Status { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
