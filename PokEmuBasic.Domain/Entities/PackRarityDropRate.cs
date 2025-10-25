using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class PackRarityDropRate
    {
        public int PackId { get; set; }
        public int RarityId { get; set; }
        public decimal DropRate { get; set; }

        public Pack Pack { get; set; } = default!;
        public Rarity Rarity { get; set; } = default!;
    }
}
