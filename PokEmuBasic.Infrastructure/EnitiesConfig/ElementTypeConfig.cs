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
    public class ElementTypeConfig : IEntityTypeConfiguration<ElementType>
    {
        public void Configure(EntityTypeBuilder<ElementType> builder)
        {
            builder.ToTable("element_types");

            builder.HasKey(et => et.Id);

            builder.Property(et => et.TypeName)
                .HasColumnName("type_name")
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
