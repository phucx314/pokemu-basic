using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class UserConfig : BaseEntityConfig<User>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("users");

            builder.Property(u => u.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.HashedPassword)
                .HasColumnName("hashed_password")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.FullName)
                .HasColumnName("full_name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.CoinBalance)
                .HasColumnName("coin_balance")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.Avatar)
                .HasColumnName("avatar")
                .IsRequired(false)
                .HasMaxLength(255);
        }
    }
}
