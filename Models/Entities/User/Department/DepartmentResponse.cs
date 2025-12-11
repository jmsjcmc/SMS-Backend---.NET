namespace SMS_backend.Models
{
    public class DepartmentOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatorFullName { get; set; } // CREATOR
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class DepartmentWithPositionsResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CreatorFullName { get; set; } // CREATOR
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public List<PositionOnlyResponse>? Positions { get; set; } // POSITION
    }
}
