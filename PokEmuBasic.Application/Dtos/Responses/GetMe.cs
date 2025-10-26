using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class GetMe
    {
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int CoinBalance { get; set; }
        public string? Avatar { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
