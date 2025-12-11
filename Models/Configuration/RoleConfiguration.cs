using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasOne(R => R.Creator)
                .WithMany()
                .HasForeignKey(R => R.CreatorID);
        }
    }
    public class RoleLogConfiguration : IEntityTypeConfiguration<RoleLog>
    {
        public void Configure(EntityTypeBuilder<RoleLog> builder)
        {
            builder.HasOne(RL => RL.Role)
                .WithMany(R => R.RoleLogs)
                .HasForeignKey(RL => RL.RoleID);
            builder.HasOne(RL => RL.Updater)
                .WithMany()
                .HasForeignKey(RL => RL.UpdaterID);
        }
    }
}
