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
                .IsRequired(false);
            
            builder.Property(c => c.RarityId)
                .HasColumnName("rarity_id")
                .IsRequired();
            
            builder.Property(c => c.CardImage)
                .HasColumnName("card_image")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CardSuperTypeId)
                .HasColumnName("card_super_type_id")
                .IsRequired();

            builder.Property(c => c.CardSubTypeId)
                .HasColumnName("card_sub_type_id")
                .IsRequired(false); // tạm nullable

            builder.Property(c => c.ElementTypeId)
                .HasColumnName("element_type_id")
                .IsRequired(false);

            builder.Property(c => c.PowerIndex)
                .HasColumnName("power_index")
                .IsRequired(false);

            builder.Property(c => c.ExpansionId)
                .HasColumnName("expansion_id")
                .IsRequired(false);

            builder.Property(c => c.ExpansionIndex)
                .HasColumnName("expansion_index")
                .IsRequired(false);

            builder.HasOne(c => c.Rarity)
                .WithMany(r => r.Cards)
                .HasForeignKey(c => c.RarityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(c => new { c.RarityId, c.Id });

            builder.HasIndex(c => c.IndexNumber)
                .IsUnique();
        }
    }
}
