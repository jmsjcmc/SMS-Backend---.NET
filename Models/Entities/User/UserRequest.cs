namespace SMS_backend.Models
{
    public class CreateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public IFormFile? Avatar { get; set; }
    }
    public class UpdateUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public IFormFile? Avatar { get; set; }
    }
    public class LogInRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
