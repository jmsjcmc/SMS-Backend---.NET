namespace SMS_backend.Models
{
    public class ProductInventory
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateInventory { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ProductInventoryStatus? ProductInventoryStatus { get; set; }
        public ICollection<ProductInventoryLog>? ProductInventoryLogs { get; set; }
        public ICollection<DailyConsumption>? DailyConsumptions { get; set; }
    }
    public class ProductInventoryLog
    {
        public int ID { get; set; }
        public int? ProductInventoryID { get; set; }
        public ProductInventory? ProductInventory { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
