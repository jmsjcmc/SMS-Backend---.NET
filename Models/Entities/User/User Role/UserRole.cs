namespace SMS_backend.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? RoleID { get; set; }
        public Role? Role { get; set; }
        public int? AssignerID { get; set; }
        public User? Assigner { get; set; }
        public DateTime? AssignedOn { get; set; }
        public ICollection<UserRoleLog>? UserRoleLogs { get; set; }
    }
    public class UserRoleLog
    {
        public int ID { get; set; }
        public int? UserRoleID { get; set; }
        public UserRole? UserRole { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
