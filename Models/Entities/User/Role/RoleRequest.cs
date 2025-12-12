namespace SMS_backend.Models
{
    public class CreateRoleRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateRoleRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
