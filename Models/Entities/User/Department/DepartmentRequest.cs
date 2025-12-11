namespace SMS_backend.Models
{
    public class CreateDepartmentRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class UpdateDepartmentRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
