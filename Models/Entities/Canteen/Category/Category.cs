namespace SMS_backend.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<CategoryLog>? CategoryLogs { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
    public class CategoryLog
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
