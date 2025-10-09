using AutoMapper;

namespace SMS_backend.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string? Description { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<Product, ProductWithCategoryResponse>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category));
        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public ICollection<Product> Product { get; set; }
    }
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, CategoryWithProductsResponse>()
                .ForMember(d => d.Product, o => o.MapFrom(s => s.Product));
        }
    }
}
