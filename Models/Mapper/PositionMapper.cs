using AutoMapper;

namespace SMS_backend.Models
{
    public class PositionMapper : Profile
    {
        public PositionMapper()
        {
            CreateMap<CreatePositionRequest, Position>();
            CreateMap<UpdatePositionRequest, Position>();
        }
    }
}
