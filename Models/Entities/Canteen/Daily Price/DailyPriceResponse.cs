namespace SMS_backend.Models
{
    public class DailyPricesOnlyResponse
    {
        public int ID { get; set; }
        public string? ProductName { get; set; } // PRODUCT
        public string? CategoryName { get; set; } // PRODUCT > CATEGORY
        public string? Price { get; set; }
    }
}
