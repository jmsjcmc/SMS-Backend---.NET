using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class DailyConsumptionConfiguration : IEntityTypeConfiguration<DailyConsumption>
    {
        public void Configure(EntityTypeBuilder<DailyConsumption> builder)
        {
            builder.HasOne(DC => DC.Product)
                .WithMany(P => P.DailyConsumptions)
                .HasForeignKey(DC => DC.ProductID);
            builder.HasOne(DC => DC.Buyer)
                .WithMany()
                .HasForeignKey(DC => DC.BuyerID);
            builder.HasOne(DC => DC.Approver)
                .WithMany()
                .HasForeignKey(DC => DC.ApproverID);
            builder.HasOne(DC => DC.ProductInventory)
                .WithMany(PI => PI.DailyConsumptions)
                .HasForeignKey(DC => DC.ProductInventoryID);
        }
    }
    public class DailyConsumptionLogConfiguration : IEntityTypeConfiguration<DailyConsumptionLog>
    {
        public void Configure(EntityTypeBuilder<DailyConsumptionLog> builder)
        {
            builder.HasOne(DCL => DCL.DailyConsumption)
                .WithMany(DC => DC.DailyConsumptionLogs)
                .HasForeignKey(DCL => DCL.DailyConsumptionID);
            builder.HasOne(DCL => DCL.Updater)
                .WithMany()
                .HasForeignKey(DCL => DCL.UpdaterID);
        }
    }
}
