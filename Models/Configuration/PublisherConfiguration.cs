using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasOne(P => P.Creator)
                .WithMany()
                .HasForeignKey(P => P.CreatorID);
        }
    }
    public class PublisherLogConfiguration : IEntityTypeConfiguration<PublisherLog>
    {
        public void Configure(EntityTypeBuilder<PublisherLog> builder)
        {
            builder.HasOne(PL => PL.Publisher)
                .WithMany(P => P.PublisherLogs)
                .HasForeignKey(PL => PL.PublisherID);
            builder.HasOne(PL => PL.Updater)
                .WithMany()
                .HasForeignKey(PL => PL.UpdaterID);
        }
    }
}
