namespace SMS_backend.Models
{
    public class Classroom
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? AdviserID { get; set; }
        public User? Adviser { get; set; }
        public string? SchoolYear { get; set; }
        public ICollection<ClassroomLog>? ClassroomLogs { get; set; }
    }
    public class ClassroomLog
    {
        public int ID { get; set; }
        public int? ClassroomID { get; set; }
        public Classroom? Classroom { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
