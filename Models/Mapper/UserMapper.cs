using AutoMapper;

namespace SMS_backend.Models
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(D => D.Password, O => O.Ignore());
            CreateMap<UpdateUserRequest, User>()
                .ForMember(D => D.Password, O => O.Ignore());
        }
    }
}