using AutoMapper;

namespace SMS_backend.Models
{
    public class DailyConsumptionMapper : Profile
    {
        public DailyConsumptionMapper()
        {
            CreateMap<CreateDailyConsumptionRequest, DailyConsumption>();
            CreateMap<UpdateDailyConsumptionRequest, DailyConsumption>();
        }
    }
}
