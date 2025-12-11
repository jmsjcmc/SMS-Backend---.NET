namespace SMS_backend.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<RoleLog>? RoleLogs { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
    public class RoleLog
    {
        public int ID { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}