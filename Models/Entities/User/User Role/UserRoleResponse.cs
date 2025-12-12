namespace SMS_backend.Models
{
    public class UserRoleResponse
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string? UserFullName { get; set; }
        public int? RoleID { get; set; }
        public string? RoleName { get; set; }
    }
}
