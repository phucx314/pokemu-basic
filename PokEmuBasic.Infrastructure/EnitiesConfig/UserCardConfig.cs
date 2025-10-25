using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class UserCardConfig : BaseEntityConfig<UserCard>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserCard> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("user_cards");
            
            builder.Property(uc => uc.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            
            builder.Property(uc => uc.CardId)
                .HasColumnName("card_id")
                .IsRequired();
            
            builder.HasOne(uc => uc.User)
                .WithMany(u => u.UserCards)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict); // prevent deleting user from deleting associated cards

            builder.HasOne(uc => uc.Card)
                .WithMany(c => c.UserCards)
                .HasForeignKey(uc => uc.CardId)
                .OnDelete(DeleteBehavior.Restrict); // prevent deleting card from deleting associated users
        }
    }
}
