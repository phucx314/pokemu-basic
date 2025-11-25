using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class GetExpansionOptionsResponse
    {
        public int Id { get; set; }
        public string ExpansionName { get; set; } = default!;
        public string ExpansionCode { get; set; } = default!;
        public string ExpansionImage { get; set; } = default!;
    }
}
