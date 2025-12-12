using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SMS_backend.Models
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasOne(RT => RT.User)
                .WithMany(U => U.RefreshTokens)
                .HasForeignKey(RT => RT.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
