using AutoMapper;
using SMS_backend.Models;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    public interface ProductInterface
    {
        Task<List<ProductResponse>> ProductsList(string searchTerm);
        Task<Pagination<ProductResponse>> PaginatedProducts(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<ProductResponse>> ActiveProductsList(string searchTerm);
        Task<Pagination<ProductResponse>> PaginatedActiveProducts(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<ProductWithCategoryResponse>> ProductWithCategoryList(string searchTerm);
        Task<Pagination<ProductWithCategoryResponse>> PaginatedProductWithCategory(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<ProductResponse> GetProductByID(int id);
        Task<ProductWithCategoryResponse> GetProductWithCategoryByID(int id);
        Task<ProductResponse> CreateProduct(CreateProductRequest request);
        Task<ProductResponse> UpdateProductByID(UpdateProductRequest request, int id);
        Task<ProductResponse> RemoveProductByID(int id);
        Task<ProductResponse> DeleteProductByID(int id);
    }
    public class ProductService : ProductInterface
    {
        private readonly IMapper _mapper;
        private readonly ProductQueries _queries;
        private readonly Db _context;
        public ProductService(IMapper mapper, ProductQueries queries, Db context)
        {
            _mapper = mapper;
            _queries = queries;
            _context = context;
        }
        // [HttpGet("products/list")]
        public async Task<List<ProductResponse>> ProductsList(string searchTerm)
        {
            var products = await _queries.ProductsList(searchTerm);
            return _mapper.Map<List<ProductResponse>>(products);
        }
        // [HttpGet("products/paginated")]
        public async Task<Pagination<ProductResponse>> PaginatedProducts(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedProducts(searchTerm);
            return await PaginationHelper.PaginateAndMap<Product, ProductResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("products/active-list")]
        public async Task<List<ProductResponse>> ActiveProductsList(string searchTerm)
        {
            var products = await _queries.ActiveProductsList(searchTerm);
            return _mapper.Map<List<ProductResponse>>(products);
        }
        // [HttpGet("products/active-paginated")]
        public async Task<Pagination<ProductResponse>> PaginatedActiveProducts(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveProducts(searchTerm);
            return await PaginationHelper.PaginateAndMap<Product, ProductResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("products/list-with-category")]
        public async Task<List<ProductWithCategoryResponse>> ProductWithCategoryList(string searchTerm)
        {
            var product = await _queries.ActiveProductsList(searchTerm);
            return _mapper.Map<List<ProductWithCategoryResponse>>(product);
        }
        // [HttpGet("products/paginated-with-category")]
        public async Task<Pagination<ProductWithCategoryResponse>> PaginatedProductWithCategory(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _queries.PaginatedActiveProducts(searchTerm);
            return await PaginationHelper.PaginateAndMap<Product, ProductWithCategoryResponse>(query, pageNumber, pageSize, _mapper);
        }
        // [HttpGet("product/{id}")]
        public async Task<ProductResponse> GetProductByID(int id)
        {
            var product = await _queries.GetProductByID(id);

            return _mapper.Map<ProductResponse>(product);
        }
        // [HttpGet("product/with-category/{id}")]
        public async Task<ProductWithCategoryResponse> GetProductWithCategoryByID(int id)
        {
            var product = await _queries.GetProductByID(id);

            return _mapper.Map<ProductWithCategoryResponse>(product);
        }
        // [HttpPost("product/create")]
        public async Task<ProductResponse> CreateProduct(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);

            product.RecordStatus = RecordStatus.Active;

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductResponse>(product);
        }
        // [HttpPatch("product/update/{id}")]
        public async Task<ProductResponse> UpdateProductByID(UpdateProductRequest request, int id)
        {
            var product = await _queries.PatchProductByID(id);

            _mapper.Map(product, request);

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductResponse>(product);
        }
        // [HttpPatch("product/toggle-status/{id}")]
        public async Task<ProductResponse> RemoveProductByID(int id)
        {
            var product = await _queries.PatchProductByID(id);

            product.RecordStatus = product.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductResponse>(product);
        }
        // [HttpDelete("product/delete/{id}")]
        public async Task<ProductResponse> DeleteProductByID(int id)
        {
            var product = await _queries.PatchProductByID(id);

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductResponse>(product);
        }
    }
}
