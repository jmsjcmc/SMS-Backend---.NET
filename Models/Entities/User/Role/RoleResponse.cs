namespace SMS_backend.Models
{
    public class RoleOnlyResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}
