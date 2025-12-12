using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasOne(A => A.Creator)
                .WithMany()
                .HasForeignKey(A => A.CreatorID);
        }
    }
    public class AuthorLogConfiguration : IEntityTypeConfiguration<AuthorLog>
    {
        public void Configure(EntityTypeBuilder<AuthorLog> builder)
        {
            builder.HasOne(AL => AL.Author)
                .WithMany(A => A.AuthorLogs)
                .HasForeignKey(AL => AL.AuthorID);
            builder.HasOne(AL => AL.Updater)
                .WithMany()
                .HasForeignKey(AL => AL.UpdaterID);
        }
    }
}
