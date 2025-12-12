using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(B => B.Author)
                .WithMany(A => A.Books)
                .HasForeignKey(B => B.AuthorID);
            builder.HasOne(B => B.Publisher)
                .WithMany(P => P.Books)
                .HasForeignKey(B => B.PublisherID);
            builder.HasOne(B => B.Creator)
                .WithMany()
                .HasForeignKey(B => B.CreatorID);
        }
    }
    public class BookLogConfiguration : IEntityTypeConfiguration<BookLog>
    {
        public void Configure(EntityTypeBuilder<BookLog> builder)
        {
            builder.HasOne(BL => BL.Book)
                .WithMany(B => B.BookLogs)
                .HasForeignKey(BL => BL.BookID);
            builder.HasOne(BL => BL.Updater)
                .WithMany()
                .HasForeignKey(BL => BL.UpdaterID);
        }
    }
}
