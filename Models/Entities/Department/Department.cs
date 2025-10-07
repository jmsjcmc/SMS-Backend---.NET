using AutoMapper;

namespace SMS_backend.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } = null;
        public ICollection<Position> Position { get; set; }
    }
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {

            CreateMap<Department, DepartmentResponse>();
            CreateMap<Department, DepartmentWithPositionResponse>()
                .ForMember(d => d.Position, o => o.MapFrom(s => s.Position));
        }
    }
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } = null;
    }
    public class PositionMapper : Profile
    {
        public PositionMapper()
        {
            CreateMap<CreatePositionRequest, Position>();
            CreateMap<UpdatePositionRequest, Position>();
            CreateMap<Position, PositionResponse>();
            CreateMap<Position, PositionWithDepartmentResponse>()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.Name));
        }
    }
}
