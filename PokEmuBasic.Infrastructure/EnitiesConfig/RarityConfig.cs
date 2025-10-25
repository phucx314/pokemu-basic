using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.EnitiesConfig
{
    public class RarityConfig : BaseEntityConfig<Rarity>
    {
        override public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rarity> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("rarities");
            
            builder.Property(r => r.RarityName)
                .HasColumnName("rarity_name")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
