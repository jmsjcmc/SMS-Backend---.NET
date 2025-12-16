using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class DailyPriceConfiguration : IEntityTypeConfiguration<DailyPrice>
    {
        public void Configure(EntityTypeBuilder<DailyPrice> builder)
        {
            builder.HasOne(DP => DP.Product)
                .WithMany(P => P.DailyPrices)
                .HasForeignKey(DP => DP.ProductID);
            builder.HasOne(DP => DP.Creator)
                .WithMany()
                .HasForeignKey(DP => DP.CreatorID);
        }
    }
    public class DailyPriceLogConfiguration : IEntityTypeConfiguration<DailyPriceLog>
    {
        public void Configure(EntityTypeBuilder<DailyPriceLog> builder)
        {
            builder.HasOne(DPL => DPL.DailyPrice)
                .WithMany(DP => DP.DailyPriceLogs)
                .HasForeignKey(DPL => DPL.DailyPriceID);
            builder.HasOne(DPL => DPL.Updater)
                .WithMany()
                .HasForeignKey(DPL => DPL.UpdaterID);
        }
    }
}
