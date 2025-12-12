namespace SMS_backend.Models
{
    public class CreateAuthorRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AuthorityName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
        public string? VIAF_ID { get; set; }
        public string? WebSiteURL { get; set; }
    }
    public class UpdateAuthorRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AuthorityName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
        public string? VIAF_ID { get; set; }
        public string? WebSiteURL { get; set; }
    }
}
