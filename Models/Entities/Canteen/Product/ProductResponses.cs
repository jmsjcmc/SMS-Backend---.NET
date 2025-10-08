namespace SMS_backend.Models.Entities
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
    public class ProductWithCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public CategoryResponse Category { get; set; } // Category
    }
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
    public class CategoryWithProductsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public List<ProductResponse> Product { get; set; } // Product
    }
}
