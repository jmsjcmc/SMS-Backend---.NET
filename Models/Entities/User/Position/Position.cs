namespace SMS_backend.Models
{
    public class Position
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<PositionLog>? PositionLogs { get; set; }
    }
    public class PositionLog
    {
        public int ID { get; set; }
        public int? PositionID { get; set; }
        public Position? Position { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}