namespace SMS_backend.Models
{
    public enum AuthorStatus
    {
        Pending = 0,
        Review = 1,
        Active = 2,
        Deceased = 3
    }
    public class Author
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AuthorityName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Nationality { get; set; }
        public string? Biography { get; set; }
        public string? VIAF_ID { get; set; }
        public string? WebSiteURL { get; set; }
        public AuthorStatus? AuthorStatus { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<AuthorLog>? AuthorLogs { get; set; }
    }
    public class AuthorLog
    {
        public int ID { get; set; }
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
