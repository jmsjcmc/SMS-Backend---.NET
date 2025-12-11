using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(U => U.Creator)
                .WithMany()
                .HasForeignKey(U => U.CreatorID);
        }
    }
    public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.HasOne(UL => UL.User)
                .WithMany(U => U.UserLogs)
                .HasForeignKey(UL => UL.UserID);
            builder.HasOne(UL => UL.Updater)
                .WithMany()
                .HasForeignKey(UL => UL.UpdaterID);
        }
    }
}