namespace SMS_backend.Models
{
    public class RefreshToken
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public string? Token { get; set; }
        public string? JwtID { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? ReplacedByToken { get; set; }
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }
        public int MyProperty { get; set; }
    }
}
