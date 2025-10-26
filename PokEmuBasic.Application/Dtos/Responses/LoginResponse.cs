using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Responses
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; } = default!;
        public GetMe AuthInfo { get; set; } = default!;
    }
}
