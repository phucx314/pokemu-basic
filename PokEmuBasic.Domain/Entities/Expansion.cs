using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class Expansion : BaseEntity
    {
        public string ExpansionName { get; set; } = default!;
        public string ExpansionCode { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public int? PrefixCode { get; set; } // cột tạm
        public string ExpansionImage { get; set; } = default!;

        public ICollection<Card> Cards { get; set; } = [];
        public ICollection<Pack> Packs { get; set; } = [];
    }
}
