using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models.Entities;
using SMS_backend.Utils;


namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("product/create")]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductRequest request)
        {
            var response = await _productService.CreateProduct(request);
            return response;
        }
        [HttpPatch("product/update/{id}")]
        public async Task<ActionResult<ProductResponse>> UpdateProductByID([FromBody] UpdateProductRequest request, int id)
        {
            var response = await _productService.UpdateProductByID(request, id);
            return response;
        }
        [HttpPatch("product/toggle-status/{id}")]
        public async Task<ActionResult<ProductResponse>> RemoveDepartmentByID(int id)
        {
            var response = await _productService.RemoveProductByID(id);
            return response;
        }
        [HttpDelete("product/delete/{id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProductByID(int id)
        {
            var response = await _productService.DeleteProductByID(id);
            return response;
        }
        [HttpGet("products/list")]
        public async Task<ActionResult<List<ProductResponse>>> ProductsList(string searchTerm)
        {
            var response = await _productService.ProductsList(searchTerm);
            return response;
        }
        [HttpGet("products/paginated")]
        public async Task<ActionResult<Pagination<ProductResponse>>> PaginatedProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _productService.PaginatedProducts(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("products/active-list")]
        public async Task<ActionResult<List<ProductResponse>>> ActiveProductsList(string searchTerm)
        {
            var response = await _productService.ActiveProductsList(searchTerm);
            return response;
        }
        [HttpGet("products/active-paginated")]
        public async Task<ActionResult<Pagination<ProductResponse>>> PaginatedActiveProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _productService.PaginatedActiveProducts(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("products/list-with-category")]
        public async Task<ActionResult<List<ProductWithCategoryResponse>>> ProductWithCategoryList(string searchTerm)
        {
            var response = await _productService.ProductWithCategoryList(searchTerm);
            return response;
        }
        [HttpGet("products/paginated-with-category")]
        public async Task<ActionResult<Pagination<ProductWithCategoryResponse>>> PaginatedProductWithCategory(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _productService.PaginatedProductWithCategory(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductByID(int id)
        {
            var response = await _productService.GetProductByID(id);
            return response;
        }
        [HttpGet("product/with-category/{id}")]
        public async Task<ActionResult<ProductWithCategoryResponse>> GetProductWithCategoryByID(int id)
        {
            var response = await _productService.GetProductWithCategoryByID(id);
            return response;
        }
    }
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("category/create")]
        public async Task<ActionResult<CategoryResponse>> CreateCategory(string categoryName)
        {
            var response = await _categoryService.CreateCategory(categoryName);
            return response;
        }
        [HttpPatch("category/update/{id}")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategoryByID(string categoryName, int id)
        {
            var response = await _categoryService.UpdateCategoryByID(categoryName, id);
            return response;
        }
        [HttpPatch("category/toggle-status/{id}")]
        public async Task<ActionResult<CategoryResponse>> RemoveCategoryByID(int id)
        {
            var response = await _categoryService.RemoveCategoryByID(id);
            return response;
        }
        [HttpDelete("category/delete/{id}")]
        public async Task<ActionResult<CategoryResponse>> DeleteCategoryByID(int id)
        {
            var response = await _categoryService.DeleteCategoryByID(id);
            return response;
        }
        [HttpGet("categories/list")]
        public async Task<ActionResult<List<CategoryResponse>>> CategoriesList(string searchTerm)
        {
            var response = await _categoryService.CategoriesList(searchTerm);
            return response;
        }
        [HttpGet("categories/paginated")]
        public async Task<ActionResult<Pagination<CategoryResponse>>> PaginatedCategories(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _categoryService.PaginatedCategories(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("categories/active-list")]
        public async Task<ActionResult<List<CategoryResponse>>> ActiveCategoriesList(string searchTerm)
        {
            var response = await _categoryService.ActiveCategoriesList(searchTerm);
            return response;
        }
        [HttpGet("categories/active-paginated")]
        public async Task<ActionResult<Pagination<CategoryResponse>>> PaginatedActiveCategories(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _categoryService.PaginatedActiveCategories(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("categories/list-with-products")]
        public async Task<ActionResult<List<CategoryWithProductsResponse>>> CategoryWithProductsList(string searchTerm)
        {
            var response = await _categoryService.CategoryWithProductsList(searchTerm);
            return response;
        }
        [HttpGet("categories/paginated-with-products")]
        public async Task<ActionResult<Pagination<CategoryWithProductsResponse>>> PaginatedCategoryWithProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _categoryService.PaginatedCategoryWithProducts(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("category/{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryByID(int id)
        {
            var response = await _categoryService.GetCategoryByID(id);
            return response;
        }
        [HttpGet("category/with-product/{id}")]
        public async Task<ActionResult<CategoryWithProductsResponse>> GetCategoryWithProductsByID(int id)
        {
            var response = await _categoryService.GetCategoryWithProductsByID(id);
            return response;
        }
    }
}
