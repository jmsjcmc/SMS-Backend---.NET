namespace SMS_backend.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? ISBN13 { get; set; }
        public string? ISBN10 { get; set; }
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public string? PublicationYear { get; set; }
        public string? EditionNumber { get; set; }
        public string? Format { get; set; }
        public string? LanguageCode { get; set; }
        public string? DeweyDecimal { get; set; }
        public string? Summary { get; set; }
        public string? ImageURL { get; set; }
        public int? TotalPages { get; set; }
        public bool? IsDigital { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<BookLog>? BookLogs { get; set; }
    }
    public class BookLog
    {
        public int ID { get; set; }
        public int? BookID { get; set; }
        public Book? Book { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
