using AutoMapper;

namespace SMS_backend.Models
{
    public class ProductInventoryMapper : Profile
    {
        public ProductInventoryMapper()
        {
            CreateMap<CreateProductInventoryRequest, ProductInventory>();
            CreateMap<UpdateProductInventoryRequest, ProductInventory>();
        }
    }
}
