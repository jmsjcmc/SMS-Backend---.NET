namespace SMS_backend.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? Name { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<ProductLog>? ProductLogs { get; set; }
        public ICollection<ProductInventory>? ProductInventories { get; set; }
        public ICollection<DailyConsumption>? DailyConsumptions { get; set; }
    }
    public class ProductLog
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
