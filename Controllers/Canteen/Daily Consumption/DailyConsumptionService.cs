using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMS_backend.Models;
using SMS_backend.Utils;
using System.Security.Claims;

namespace SMS_backend.Controllers
{
    public class DailyConsumptionService : IDailyConsumptionService
    {
        private readonly Db _context;
        private readonly IMapper _mapper;
        private readonly DailyConsumptionQuery _dailyConsumptionQuery;
        public DailyConsumptionService(Db context, IMapper mapper, DailyConsumptionQuery dailyConsumptionQuery)
        {
            _context = context;
            _mapper = mapper;
            _dailyConsumptionQuery = dailyConsumptionQuery;
        }
        public async Task<DailyConsumptionOnlyResponse?> CreateDailyConsumptionAsync(CreateDailyConsumptionRequest request, ClaimsPrincipal creator)
        {
            var newDailyConsumption = _mapper.Map<DailyConsumption>(request);
            newDailyConsumption.BuyerID = AuthUserHelper.GetUserID(creator);
            newDailyConsumption.BuyOn = DateTimeHelper.GetPhilippineStandardTime();

            await _context.DailyConsumptions.AddAsync(newDailyConsumption);
            await _context.SaveChangesAsync();

            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseByIDAsync(newDailyConsumption.ID);
        }
        public async Task<DailyConsumptionOnlyResponse?> PatchDailyConsumptionByIDAsync(int ID, UpdateDailyConsumptionRequest request, ClaimsPrincipal updater)
        {
            var query = await _dailyConsumptionQuery.PatchDailyConsumptionByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var dailyConsumptionLog = new DailyConsumptionLog
            {
                DailyConsumptionID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.DailyConsumptionLogs.AddAsync(dailyConsumptionLog);
            await _context.SaveChangesAsync();

            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<DailyConsumptionOnlyResponse?> PatchInventoryStatusByIDAsync(int ID, ProductConsumptionStatus? productConsumptionStatus, ClaimsPrincipal updater)
        {
            var query = await _dailyConsumptionQuery.PatchDailyConsumptionByIDAsync(ID);

            query.ProductConsumptionStatus = productConsumptionStatus;

            switch (productConsumptionStatus)
            {
                case ProductConsumptionStatus.Approved:
                    break;
                case ProductConsumptionStatus.ForPayment:
                    break;
                case ProductConsumptionStatus.ForReleasing:
                    break;
                case ProductConsumptionStatus.Released:
                    break;
                case ProductConsumptionStatus.Closed:
                    break;
            }

            await _context.SaveChangesAsync();

            var dailyConsumptionLog = new DailyConsumptionLog
            {
                DailyConsumptionID = query.ID,
                UpdaterID = AuthUserHelper.GetUserID(updater),
                UpdatedOn = DateTimeHelper.GetPhilippineStandardTime()
            };

            await _context.DailyConsumptionLogs.AddAsync(dailyConsumptionLog);
            await _context.SaveChangesAsync();

            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<DailyConsumptionOnlyResponse?> DeleteDailyConsumptionByIDAsync(int ID)
        {
            var query = await _dailyConsumptionQuery.PatchDailyConsumptionByIDAsync(ID);

            _context.DailyConsumptions.Remove(query);
            await _context.SaveChangesAsync();

            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseByIDAsync(query.ID);
        }
        public async Task<DailyConsumptionOnlyResponse?> GetDailyConsumptionByIDAsync(int ID)
        {
            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseByIDAsync(ID);
        }
        public async Task<Pagination<DailyConsumptionOnlyResponse>> GetPaginatedDailyConsumptionAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            ProductConsumptionStatus? productConsumptionStatus)
        {
            var query = _dailyConsumptionQuery.DailyConsumptionOnlyResponseAsync(searchTerm, productConsumptionStatus);
            return await PaginationHelper.PaginatedAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<DailyConsumptionOnlyResponse>> GetListedDailyConsumptionAsync(string? searchTerm, ProductConsumptionStatus? productConsumptionStatus)
        {
            return await _dailyConsumptionQuery.DailyConsumptionOnlyResponseAsync(searchTerm, productConsumptionStatus).ToListAsync();
        }
    }
}
