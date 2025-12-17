using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            builder.HasOne(PI => PI.Product)
                .WithMany(P => P.ProductInventories)
                .HasForeignKey(PI => PI.ProductID);
            builder.HasOne(PI => PI.Creator)
                .WithMany()
                .HasForeignKey(PI => PI.CreatorID);
        }
    }
    public class ProductInventoryLogConfiguration : IEntityTypeConfiguration<ProductInventoryLog>
    {
        public void Configure(EntityTypeBuilder<ProductInventoryLog> builder)
        {
            builder.HasOne(PIL => PIL.ProductInventory)
                .WithMany(PI => PI.ProductInventoryLogs)
                .HasForeignKey(PIL => PIL.ProductInventoryID);
            builder.HasOne(PIL => PIL.Updater)
                .WithMany()
                .HasForeignKey(PIL => PIL.UpdaterID);
        }
    }
}
