namespace SMS_backend.Models
{
    public class ProductOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ProductWithCategoryResponse
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; } // CATEGORY
        public string? CategoryName { get; set; } // CATEGORY
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}
