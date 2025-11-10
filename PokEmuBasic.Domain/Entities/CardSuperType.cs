using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class CardSuperType
    {
        public int Id { get; set; }
        public string SuperTypeName { get; set; } = default!;

        public ICollection<Card> Cards { get; set; } = [];
    }
}
