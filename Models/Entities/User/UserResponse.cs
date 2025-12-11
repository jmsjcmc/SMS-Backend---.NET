namespace SMS_backend.Models
{
    public class UserOnlyResponse
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Avatar { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class UserWithRoleResponse
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Avatar { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public List<string>? Roles { get; set; }
    }
    public class LogInResponse
    {
        public string? AccessToken { get; set; }
    }
}