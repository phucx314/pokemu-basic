using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class DropRateResponse
    {
        public string RarityName { get; set; } = default!;
        public decimal DropRate { get; set; }
    }
}
