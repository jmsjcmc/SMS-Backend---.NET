using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models.Entities
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasOne(p => p.Department)
                .WithMany(d => d.Position)
                .HasForeignKey(p => p.DepartmentId);
        }
    }
}
