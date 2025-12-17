using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductInventoryController : ControllerBase, IProductInventoryController
    {
        private readonly ProductInventoryService _productInventoryService;
        public ProductInventoryController(ProductInventoryService productInventoryService)
        {
            _productInventoryService = productInventoryService;
        }
        [HttpPost("product-inventory/create")]
        public async Task<ActionResult<ProductInventoryOnlyResponse?>> CreateProductInventoryAsync(CreateProductInventoryRequest request)
        {
            var response = await _productInventoryService.CreateProductInventoryAsync(request, User);
            return response;
        }
        [HttpPatch("product-inventory/{ID}/patch")]
        public async Task<ActionResult<ProductInventoryOnlyResponse?>> PatchProductInventoryByIDAsync(int ID, UpdateProductInventoryRequest request)
        {
            var response = await _productInventoryService.PatchProductInventoryByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("product-inventory/{ID}/delete")]
        public async Task<ActionResult<ProductInventoryOnlyResponse?>> DeleteProductInventoryByIDAsync(int ID)
        {
            var response = await _productInventoryService.DeleteProductInventoryByIDAsync(ID);
            return response;
        }
        [HttpGet("product-inventory/{ID}/daily")]
        public async Task<ActionResult<ProductInventoryOnlyResponse?>> GetProductInventoryByIDAsync(int ID)
        {
            var response = await _productInventoryService.GetProductInventoryByIDAsync(ID);
            return response;
        }
        [HttpGet("product-inventory/{ID}/daily-remaining")]
        public async Task<ActionResult<DailyProductInventoryResponse?>> GetRemainingInventoryForTheDayByIDAsync(int ID)
        {
            var response = await _productInventoryService.GetRemainingInventoryForTheDayByIDAsync(ID);
            return response;
        }
        [HttpGet("product-inventory/paginate")]
        public async Task<ActionResult<Pagination<ProductInventoryOnlyResponse>>> GetPaginatedProductInventoryAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm)
        {
            var response = await _productInventoryService.GetPaginatedProductInventoryAsync(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("product-inventory/paginate/remaining")]
        public async Task<ActionResult<Pagination<DailyProductInventoryResponse>>> GetPaginatedRemainingInventoryForTheDayAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm)
        {
            var response = await _productInventoryService.GetPaginatedRemainingInventoryForTheDayAsync(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("product-inventory/list")]
        public async Task<ActionResult<List<ProductInventoryOnlyResponse>>> GetListedProductInventoryAsync(string? searchTerm)
        {
            var response = await _productInventoryService.GetListedProductInventoryAsync(searchTerm);
            return response;
        }
        [HttpGet("product-inventory/list/remaining")]
        public async Task<ActionResult<List<DailyProductInventoryResponse>>> GetListedRemainingInventoryForTheDayAsync(string? searchTerm)
        {
            var response = await _productInventoryService.GetListedRemainingInventoryForTheDayAsync(searchTerm);
            return response;
        }
    }
}
