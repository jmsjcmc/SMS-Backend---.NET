namespace SMS_backend.Models.Entities
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
    public class UserWithPositionAndRoleResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public PositionResponse Position { get; set; } // Position
        public List<RoleResponse> Role { get; set; } // Role
    }
    public class RoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
    public class UsersCount
    {
        public int Total { get; set; }
        public int Active { get; set; }
    }
}
