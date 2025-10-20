namespace SMS_backend.Models.Entities
{
    public class DepartmentResponse // Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
    public class PositionResponse // Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
    public class PositionWithDepartmentResponse // Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string DepartmentName { get; set; } // Department
    }
    public class DepartmentWithPositionResponse // Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<PositionResponse> Position { get; set; } // Position
    }
    public class DepartmentsCount
    {
        public int Total { get; set; }
        public int Active { get; set; }
    }
    public class PositionsCount
    {
        public int Total { get; set; }
        public int Active { get; set; }
    }
}
