namespace SMS_backend.Models.Entities
{
    public class CreatePositionRequest
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; } = 0;
    }
    public class UpdatePositionRequest
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; } = 0;
    }
}
