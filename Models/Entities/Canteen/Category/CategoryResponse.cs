namespace SMS_backend.Models
{
    public class CategoryOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class CategoryWithProductsResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<ProductOnlyResponse>? Products { get; set; } // PRODUCT
    }
}
