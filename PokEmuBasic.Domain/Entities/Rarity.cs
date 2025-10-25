using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class Rarity : BaseEntity
    {
        public string RarityName { get; set; } = default!;

        public ICollection<Card> Cards { get; set; } = [];
        public ICollection<PackRarityDropRate> PackRarityDropRates { get; set; } = [];
    }
}
