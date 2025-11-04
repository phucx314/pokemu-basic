using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class PackConfig : BaseEntityConfig<Pack>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pack> builder)
        {
            base.Configure(builder);

            builder.ToTable("packs");
            
            builder.Property(p => p.PackName)
                .HasColumnName("pack_name")
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(p => p.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(p => p.GlobalQuantity)
                .HasColumnName("global_quantity")
                .IsRequired(false);

            builder.Property(p => p.CardQuantity)
                .HasColumnName("card_quantity")
                .IsRequired();
            
            builder.Property(p => p.PackImage)
                .HasColumnName("pack_image")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.IsFeatured)
                .HasColumnName("is_featured")
                .HasDefaultValue(false);
        }
    }
}
