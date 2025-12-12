using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("product/create")]
        public async Task<ActionResult<ProductOnlyResponse?>> CreateProductAsync(string productName)
        {
            var response = await _productService.CreateProductAsync(productName, User);
            return response;
        }
        [HttpPatch("product/{ID}/patch")]
        public async Task<ActionResult<ProductWithCategoryResponse?>> PatchProductByIDAsync(int ID, UpdateProductRequest request)
        {
            var response = await _productService.PatchProductByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("product/{ID}/toggle-status")]
        public async Task<ActionResult<ProductWithCategoryResponse?>> PatchProductStatusByIDAsync(int ID, RecordStatus? recordStatus)
        {
            var response = await _productService.PatchProductStatusByIDAsync(ID, recordStatus, User);
            return response;
        }
        [HttpDelete("product/{ID}/delete")]
        public async Task<ActionResult<ProductOnlyResponse?>> DeleteProductByIDAsync(int ID)
        {
            var response = await _productService.DeleteProductByIDAsync(ID);
            return response;
        }
        [HttpGet("product/{ID}")]
        public async Task<ActionResult<ProductWithCategoryResponse?>> GetProductByIDAsync(int ID)
        {
            var response = await _productService.GetProductByIDAsync(ID);
            return response;
        }
        [HttpGet("products/paginate")]
        public async Task<ActionResult<Pagination<ProductWithCategoryResponse>>> GetPaginatedProductsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("products/list")]
        public async Task<ActionResult<List<ProductWithCategoryResponse>>> GetListedProductsAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _productService.GetListedProductsAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
