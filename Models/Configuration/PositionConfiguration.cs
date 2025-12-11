using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasOne(P => P.Creator)
                .WithMany()
                .HasForeignKey(P => P.CreatorID);
            builder.HasOne(P => P.Department)
                .WithMany(D => D.Positions)
                .HasForeignKey(P => P.DepartmentID);
        }
    }
    public class PositionLogConfiguration : IEntityTypeConfiguration<PositionLog>
    {
        public void Configure(EntityTypeBuilder<PositionLog> builder)
        {
            builder.HasOne(PL => PL.Position)
                .WithMany(P => P.PositionLogs)
                .HasForeignKey(PL => PL.PositionID);
            builder.HasOne(PL => PL.Updater)
                .WithMany()
                .HasForeignKey(PL => PL.UpdaterID);
        }
    }
}