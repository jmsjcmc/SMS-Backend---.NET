using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasOne(S => S.Teacher)
                .WithMany()
                .HasForeignKey(S => S.TeacherID);
        }
    }
    public class SubjectLogConfiguration : IEntityTypeConfiguration<SubjectLog>
    {
        public void Configure(EntityTypeBuilder<SubjectLog> builder)
        {
            builder.HasOne(SL => SL.Subject)
                .WithMany(S => S.SubjectLogs)
                .HasForeignKey(SL => SL.SubjectID);
            builder.HasOne(SL => SL.Updater)
                .WithMany()
                .HasForeignKey(SL => SL.UpdaterID);
        }
    }
}
