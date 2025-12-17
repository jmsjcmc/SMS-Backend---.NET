namespace SMS_backend.Models
{
    public enum RecordStatus
    {
        Active = 1,
        Inactive = 0
    }
    public enum ProductInventoryStatus
    {
        Close = 0,
        Open = 1,
        ForInventory = 2,
    }
    public enum ProductConsumptionStatus
    {
        Pending = 0,
        Approved = 1,
        ForPayment = 2,
        ForReleasing = 3,
        Released = 4,
        Closed = 5
    }
}
