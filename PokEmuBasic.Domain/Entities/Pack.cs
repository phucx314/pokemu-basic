using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class Pack : BaseEntity
    {
        public string PackName { get; set; } = default!;
        public int Price { get; set; }
        public int? GlobalQuantity { get; set; }
        public int CardQuantity { get; set; }
        public string PackImage { get; set; } = default!;
        public bool IsFeatured { get; set; }
        public int? ExpansionId { get; set; }

        public Expansion? Expansion { get; set; } = default!;

        public ICollection<PackRarityDropRate> PackRarityDropRates { get; set; } = [];
    }
}
