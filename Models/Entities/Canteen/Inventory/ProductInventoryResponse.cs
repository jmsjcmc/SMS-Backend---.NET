namespace SMS_backend.Models
{
    public class ProductInventoryOnlyResponse
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } // PRODUCT
        public int? Quantity { get; set; }
        public DateTime? DateInventory { get; set; }
        public ProductInventoryStatus? ProductInvetoryStatus { get; set; }
    }
    public class DailyProductInventoryResponse
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } // PRODUCT
        public int? RemainingQuantity { get; set; } // CALCULATION FOR REMAINING QUANTITY * DAILY CONSUMPTION QUANTITY - PRODUCT INVENTORY QUANTITY
        public DateTime? DateInventory { get; set; }
        public ProductInventoryStatus? ProductInvetoryStatus { get; set; }
    }
}
