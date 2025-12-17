namespace SMS_backend.Models
{
    public class CreateDailyConsumptionRequest
    {
        public int? ProductInventoryID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
    }
    public class UpdateDailyConsumptionRequest
    {
        public int? ProductInventoryID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
    }
}
