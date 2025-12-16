namespace SMS_backend.Models
{
    public class DailyPrice
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public string? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<DailyPriceLog>? DailyPriceLogs { get; set; }
    }
    public class DailyPriceLog
    {
        public int ID { get; set; }
        public int? DailyPriceID { get; set; }
        public DailyPrice? DailyPrice { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
