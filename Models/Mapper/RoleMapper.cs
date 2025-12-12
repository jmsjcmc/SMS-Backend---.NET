using AutoMapper;

namespace SMS_backend.Models
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<UpdateRoleRequest, Role>();
        }
    }
}
