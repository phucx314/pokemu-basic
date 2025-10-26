using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Requests
{
    public class LoginRequest
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? DeviceName { get; set; } = default!;
        public string? IpAddress { get; set; }  = default!;
    }
}
