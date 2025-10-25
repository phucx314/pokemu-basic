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
    internal class PackRarityDropRateConfig : IEntityTypeConfiguration<PackRarityDropRate>
    {
        public void Configure(EntityTypeBuilder<PackRarityDropRate> builder)
        {
            builder.ToTable("pack_rarity_drop_rates");

            builder.HasKey(prd => new { prd.PackId, prd.RarityId }); // complex primary key

            builder.HasOne(prd => prd.Pack)
                   .WithMany(p => p.PackRarityDropRates)
                   .HasForeignKey(prd => prd.PackId)
                   .OnDelete(DeleteBehavior.Cascade); // when a pack is deleted, its drop rates are also deleted

            builder.HasOne(prd => prd.Rarity)
               .WithMany(r => r.PackRarityDropRates) 
               .HasForeignKey(prd => prd.RarityId)
               .OnDelete(DeleteBehavior.Restrict); // prevent deletion of a rarity if it's referenced

            builder.Property(prd => prd.DropRate)
                   .IsRequired();
        }
    }
}
