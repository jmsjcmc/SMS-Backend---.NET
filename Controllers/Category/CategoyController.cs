using Microsoft.AspNetCore.Mvc;
using SMS_backend.Models;
using SMS_backend.Utils;

namespace SMS_backend.Controllers
{
    [Route("")]
    [ApiController]
    public class CategoyController : ControllerBase, ICategoryController
    {
        private readonly CategoryService _categoryService;
        public CategoyController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("category/create")]
        public async Task<ActionResult<CategoryOnlyResponse?>> CreateCategoryAsync(string categoryName)
        {
            var response = await _categoryService.CreateCategoryAsync(categoryName, User);
            return response;
        }
        [HttpPatch("category/{ID}/patch")]
        public async Task<ActionResult<CategoryOnlyResponse?>> PatchCategoryByIDAsync(int ID, string categoryName)
        {
            var response = await _categoryService.PatchCategoryByIDAsync(ID, categoryName, User);
            return response;
        }
        [HttpPatch("category/{ID}/toggle-status")]
        public async Task<ActionResult<CategoryOnlyResponse?>> PatchCategoryStatusByIDAsync(int ID, RecordStatus recordStatus)
        {
            var response = await _categoryService.PatchCategoryStatusByIDAsync(ID, recordStatus, User);
            return response;
        }
        [HttpDelete("category/{ID}/delete")]
        public async Task<ActionResult<CategoryOnlyResponse?>> DeleteCategoryByIDAsync(int ID)
        {
            var response = await _categoryService.DeleteCategoryByIDAsync(ID);
            return response;
        }
        [HttpGet("category/{ID}")]
        public async Task<ActionResult<CategoryOnlyResponse?>> GetCategoryByIDAsync(int ID)
        {
            var response = await _categoryService.GetCategoryByIDAsync(ID);
            return response;
        }
        [HttpGet("categories/paginate")]
        public async Task<ActionResult<Pagination<CategoryOnlyResponse>>> GetPaginatedCategoriesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var response = await _categoryService.GetPaginatedCategoriesAsync(pageNumber, pageSize, searchTerm, recordStatus);
            return response;
        }
        [HttpGet("categories/list")]
        public async Task<ActionResult<List<CategoryOnlyResponse>>> GetListedCategoriesAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            var response = await _categoryService.GetListedCategoriesAsync(searchTerm, recordStatus);
            return response;
        }
    }
}
