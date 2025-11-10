using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class ElementType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = default!;
        public string TypeImage { get; set; } = default!;

        public ICollection<Card> Cards { get; set; } = [];
    }
}
