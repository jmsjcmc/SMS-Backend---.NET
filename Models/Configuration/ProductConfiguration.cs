using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.Category)
                .WithMany(C => C.Products)
                .HasForeignKey(P => P.CategoryID);
            builder.HasOne(P => P.Creator)
                .WithMany()
                .HasForeignKey(P => P.CreatorID);
        }
    }
    public class ProductLogConfiguration : IEntityTypeConfiguration<ProductLog>
    {
        public void Configure(EntityTypeBuilder<ProductLog> builder)
        {
            builder.HasOne(PL => PL.Product)
                .WithMany(P => P.ProductLogs)
                .HasForeignKey(PL => PL.ProductID);
            builder.HasOne(PL => PL.Updater)
                .WithMany()
                .HasForeignKey(PL => PL.UpdaterID);
        }
    }
}
