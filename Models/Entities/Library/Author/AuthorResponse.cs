namespace SMS_backend.Models
{
    public class AuthorOnlyResponse
    {
        public int ID { get; set; }
        public string? AuthorFullName { get; set; }
        public string? AuthorityName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
        public string? VIAF_ID { get; set; }
        public string? WebSiteURL { get; set; }
        public AuthorStatus? AuthorStatus { get; set; }
    }
}
