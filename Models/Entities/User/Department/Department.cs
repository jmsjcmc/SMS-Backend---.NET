namespace SMS_backend.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<DepartmentLog>? DepartmentLogs { get; set; }
        public ICollection<Position>? Positions { get; set; }
    }
    public class DepartmentLog
    {
        public int ID { get; set; }
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}