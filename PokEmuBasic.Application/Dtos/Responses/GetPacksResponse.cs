using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class GetPacksResponse
    {
        public int Id { get; set; }
        public string PackName { get; set; } = default!;
        public string PackImage { get; set; } = default!;
        public int Price { get; set; }
        public int CardQuantity { get; set; }
        public int? GlobalQuantity { get; set; }
        public bool IsFeatured { get; set; }
    }
}
