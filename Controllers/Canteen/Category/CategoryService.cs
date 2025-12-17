using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class CategoryService : ICategoryService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;
        private readonly CategoryQuery _categoryQuery;
        public CategoryService(Db context, IMapper mapper, CategoryQuery categoryQuery)
        {
            _context = context;
            _mapper = mapper;
            _categoryQuery = categoryQuery;
        }
        public async Task<CategoryOnlyResponse?> CreateCategoryAsync(string categoryName, ClaimsPrincipal creator)
        {
            var newCategory = new Category
            {
                Name = categoryName,
                RecordStatus = RecordStatus.Active,
                CreatorID = AuthUserHelper.GetUserID(creator),
                CreatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return await _categoryQuery.CategoryOnlyResponseByIDAsync(newCategory.ID);
        }
        public async Task<CategoryOnlyResponse?> PatchCategoryByIDAsync(int ID, string categoryName, ClaimsPrincipal updater)
        {
            var query = await _categoryQuery.PatchCategoryByIDAsync(ID);

            query.Name = categoryName;

            await _context.SaveChangesAsync();

            var categoryLog = new CategoryLog
            {
                CategoryID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.CategoryLogs.AddAsync(categoryLog);
            await _context.SaveChangesAsync();

            return await _categoryQuery.CategoryOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CategoryOnlyResponse?> PatchCategoryStatusByIDAsync(int ID, RecordStatus recordStatus, ClaimsPrincipal updater)
        {
            var query = await _categoryQuery.PatchCategoryByIDAsync(ID);

            query.RecordStatus = recordStatus;

            await _context.SaveChangesAsync();

            var categoryLog = new CategoryLog
            {
                CategoryID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.CategoryLogs.AddAsync(categoryLog);
            await _context.SaveChangesAsync();

            return await _categoryQuery.CategoryOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CategoryOnlyResponse?> DeleteCategoryByIDAsync(int ID)
        {
            var query = await _categoryQuery.PatchCategoryByIDAsync(ID);

            _context.Categories.Remove(query);
            await _context.SaveChangesAsync();

            return await _categoryQuery.CategoryOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CategoryOnlyResponse?> GetCategoryByIDAsync(int ID)
        {
            return await _categoryQuery.CategoryOnlyResponseByIDAsync(ID);
        }
        public async Task<Pagination<CategoryOnlyResponse>> GetPaginatedCategoriesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus)
        {
            var query = _categoryQuery.CategoryOnlyResponseAsync(searchTerm, recordStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<CategoryOnlyResponse>> GetListedCategoriesAsync(string? searchTerm, RecordStatus? recordStatus)
        {
            return await _categoryQuery.CategoryOnlyResponseAsync(searchTerm, recordStatus).ToListAsync();
        }
    }
}
