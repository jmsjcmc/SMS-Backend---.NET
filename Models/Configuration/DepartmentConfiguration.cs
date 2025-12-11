using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(D => D.Creator)
                .WithMany()
                .HasForeignKey(D => D.CreatorID);
        }
    }
    public class DepartmentLogConfiguration : IEntityTypeConfiguration<DepartmentLog>
    {
        public void Configure(EntityTypeBuilder<DepartmentLog> builder)
        {
            builder.HasOne(DL => DL.Department)
                .WithMany(D => D.DepartmentLogs)
                .HasForeignKey(DL => DL.DepartmentID);
            builder.HasOne(DL => DL.Updater)
                .WithMany()
                .HasForeignKey(DL => DL.UpdaterID);
        }
    }
}