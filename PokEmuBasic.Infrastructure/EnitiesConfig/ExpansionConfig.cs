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
    public class ExpansionConfig : BaseEntityConfig<Expansion>
    {
        override public void Configure(EntityTypeBuilder<Expansion> builder)
        {
            base.Configure(builder);

            builder.ToTable("expansions");

            builder.Property(e => e.ExpansionName)
                .HasColumnName("expansion_name")
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(e => e.ExpansionCode)
                .HasColumnName("expansion_code")
                .IsRequired()
                .HasMaxLength(10);
            
            builder.Property(e => e.ReleaseDate)
                .HasColumnName("release_date")
                .IsRequired()
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
            
            builder.Property(e => e.PrefixCode)
                .HasColumnName("prefix_code")
                .IsRequired(false);

            builder.Property(e => e.ExpansionImage)
                .HasColumnName("expansion_image")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
