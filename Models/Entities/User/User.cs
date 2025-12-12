namespace SMS_backend.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public int? PositionID { get; set; }
        public Position? Position { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<UserLog>? UserLogs { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
    public class UserLog
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}