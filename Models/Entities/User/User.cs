using AutoMapper;

namespace SMS_backend.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
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
                .ForMember(d => d.Password, o => o.Ignore());

            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());

            CreateMap<User, UserResponse>();
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
