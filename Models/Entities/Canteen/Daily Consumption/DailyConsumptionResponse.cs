namespace SMS_backend.Models
{
    public class DailyConsumptionOnlyResponse
    {
        public int ID { get; set; }
        public int? ProductInventoryID { get; set; }
        public string? ProductName { get; set; } // PRODUCT
        public int? Quantity { get; set; }
        public ProductConsumptionStatus? ProductConsumptionStatus { get; set; }
    }
}
