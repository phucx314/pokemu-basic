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
    public class CardSuperTypeConfig : IEntityTypeConfiguration<CardSuperType>
    {
        public void Configure(EntityTypeBuilder<CardSuperType> builder)
        {
            builder.ToTable("card_super_types");

            builder.HasKey(cst => cst.Id);

            builder.Property(cst => cst.SuperTypeName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("super_type_name")
                .IsRequired();
        }
    }
}
