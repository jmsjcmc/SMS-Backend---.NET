using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.HasOne(C => C.Adviser)
                .WithMany()
                .HasForeignKey(C => C.AdviserID);
        }
    }
    public class ClassroomLogConfiguration : IEntityTypeConfiguration<ClassroomLog>
    {
        public void Configure(EntityTypeBuilder<ClassroomLog> builder)
        {
            builder.HasOne(CL => CL.Classroom)
                .WithMany(C => C.ClassroomLogs)
                .HasForeignKey(CL => CL.ClassroomID);
        }
    }
}
