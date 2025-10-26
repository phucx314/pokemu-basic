using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class UserSessionConfig : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.HasKey(us => us.Id);

            builder.Property(us => us.RefreshToken)
                .IsRequired();

            builder.Property(us => us.RefreshTokenExpiryTime)
                .IsRequired();

            builder.Property(us => us.DeviceName)
                .HasMaxLength(255);

            builder.Property(us => us.IpAddress)
                .HasMaxLength(50);

            // danh index
            builder.HasIndex(us => us.RefreshToken)
                .IsUnique();

            // one-to-many
            builder.HasOne(us => us.User)
                .WithMany(u => u.UserSessions)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(us => us.CreatedAt)
                .HasDefaultValueSql("NOW()") // ✅ PostgreSQL dùng NOW()
                .ValueGeneratedOnAdd();

            builder.Property(us => us.UpdatedAt)
                .HasDefaultValueSql("NOW()") // ✅ PostgreSQL dùng NOW()
                .ValueGeneratedOnAdd();
        }
    }
}
