using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(UR => UR.User)
                .WithMany(U => U.UserRoles)
                .HasForeignKey(UR => UR.UserID);
            builder.HasOne(UR => UR.Role)
                .WithMany(R => R.UserRoles)
                .HasForeignKey(UR => UR.RoleID);
            builder.HasOne(UR => UR.Assigner)
                .WithMany()
                .HasForeignKey(UR => UR.AssignerID);
        }
    }
    public class UserRoleLogConfiguration : IEntityTypeConfiguration<UserRoleLog>
    {
        public void Configure(EntityTypeBuilder<UserRoleLog> builder)
        {
            builder.HasOne(URL => URL.UserRole)
                .WithMany(UR => UR.UserRoleLogs)
                .HasForeignKey(URL => URL.UserRoleID);
            builder.HasOne(URL => URL.Updater)
                .WithMany()
                .HasForeignKey(URL => URL.UpdaterID);
        }
    }
}
