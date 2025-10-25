using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class CardConfig : BaseEntityConfig<Card>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Card> builder)
        {
            base.Configure(builder);

            builder.ToTable("cards");
            
            builder.Property(c => c.CardName)
                .HasColumnName("card_name")
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(c => c.IndexNumber)
                .HasColumnName("index_number")
                .IsRequired();
            
            builder.Property(c => c.RarityId)
                .HasColumnName("rarity_id")
                .IsRequired();
            
            builder.Property(c => c.CardImage)
                .HasColumnName("card_image")
                .IsRequired()
                .HasMaxLength(255);
            
            builder.HasOne(c => c.Rarity)
                .WithMany(r => r.Cards)
                .HasForeignKey(c => c.RarityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
