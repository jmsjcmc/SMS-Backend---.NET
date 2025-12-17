namespace SMS_backend.Models
{
    public class DailyConsumption
    {
        public int ID { get; set; }
        public int? ProductInventoryID { get; set; }
        public ProductInventory? ProductInventory { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? Quantity { get; set; }
        public int? BuyerID { get; set; }
        public User? Buyer { get; set; }
        public DateTime? BuyOn { get; set; }
        public int? ApproverID { get; set; }
        public User? Approver { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public ProductConsumptionStatus? ProductConsumptionStatus { get; set; }
        public ICollection<DailyConsumptionLog>? DailyConsumptionLogs { get; set; }
    }
    public class DailyConsumptionLog
    {
        public int ID { get; set; }
        public int? DailyConsumptionID { get; set; }
        public DailyConsumption? DailyConsumption { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
