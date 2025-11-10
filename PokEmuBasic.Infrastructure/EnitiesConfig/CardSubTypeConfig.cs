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
    public class CardSubTypeConfig : IEntityTypeConfiguration<CardSubType>
    {
        public void Configure(EntityTypeBuilder<CardSubType> builder)
        {
            builder.ToTable("card_sub_types");

            builder.HasKey(cst => cst.Id);

            builder.Property(cst => cst.SubTypeName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("sub_type_name");
        }
    }
}
