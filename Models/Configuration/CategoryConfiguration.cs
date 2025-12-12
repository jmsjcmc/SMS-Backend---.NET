using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(C => C.Creator)
                .WithMany()
                .HasForeignKey(C => C.CreatorID);
        }
    }
    public class CategoryLogConfiguration : IEntityTypeConfiguration<CategoryLog>
    {
        public void Configure(EntityTypeBuilder<CategoryLog> builder)
        {
            builder.HasOne(CL => CL.Category)
                .WithMany(C => C.CategoryLogs)
                .HasForeignKey(CL => CL.CategoryID);
            builder.HasOne(CL => CL.Updater)
                .WithMany()
                .HasForeignKey(CL => CL.UpdaterID);
        }
    }
}
