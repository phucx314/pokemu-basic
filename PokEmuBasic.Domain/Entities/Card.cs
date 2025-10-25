using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardName { get; set; } = default!;
        public int IndexNumber { get; set; }
        public int RarityId { get; set; }
        public string CardImage { get; set; } = default!;

        public Rarity Rarity { get; set; } = default!;

        public ICollection<UserCard> UserCards { get; set; } = [];
    }
}
