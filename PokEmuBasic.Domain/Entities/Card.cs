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
        public int? CardSuperTypeId { get; set; } // tạm nullable
        public int? CardSubTypeId { get; set; } // tạm nullable
        public int? ElementTypeId { get; set; }
        public int? PowerIndex { get; set; }

        public CardSuperType? CardSuperType { get; set; } = default!; // tạm nullable
        public CardSubType? CardSubType { get; set; } = default!; // tạm nullable
        public ElementType? ElementType { get; set; } = default!;
        public Rarity Rarity { get; set; } = default!;

        public ICollection<UserCard> UserCards { get; set; } = [];
    }
}
