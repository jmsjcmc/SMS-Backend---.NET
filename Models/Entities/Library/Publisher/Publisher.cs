namespace SMS_backend.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ShortCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public DateTime? DateEstablished { get; set; }
        public string? InternalNotes { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<PublisherLog>? PublisherLogs { get; set; }
    }
    public class PublisherLog
{
    public int ID { get; set; }
    public int? PublisherID { get; set; }
    public Publisher? Publisher { get; set; }
    public int? UpdaterID { get; set; }
    public User? Updater { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
}
