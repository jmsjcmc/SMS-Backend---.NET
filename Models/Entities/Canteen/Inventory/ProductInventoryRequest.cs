namespace SMS_backend.Models
{
    public class CreateProductInventoryRequest
    {
        public int? ProductID { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
    }
    public class UpdateProductInventoryRequest
    {
        public int? ProductID { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
