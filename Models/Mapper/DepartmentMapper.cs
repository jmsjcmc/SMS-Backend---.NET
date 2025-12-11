using AutoMapper;

namespace SMS_backend.Models
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<CreateDepartmentRequest, Department>();
            CreateMap<UpdateDepartmentRequest, Department>();
        }
    }
}
