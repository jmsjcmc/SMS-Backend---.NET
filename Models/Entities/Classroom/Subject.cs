namespace SMS_backend.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Day { get; set; }
        public string? Hours { get; set; }
        public int? TeacherID { get; set; }
        public User? Teacher { get; set; }
        public ICollection<SubjectLog>? SubjectLogs { get; set; }
    }
    public class SubjectLog
    {
        public int ID { get; set; }
        public int? SubjectID { get; set; }
        public Subject? Subject { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
