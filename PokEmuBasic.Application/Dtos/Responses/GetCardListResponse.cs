using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class GetCardListResponse
    {
        public int Id { get; set; }
        public string CardName { get; set; } = default!;
        public int ExpansionIndex { get; set; }
        public string CardImage { get; set; } = default!;

    }
}
