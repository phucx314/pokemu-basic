using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user, int sessionId);
        string GenerateRefreshToken();
    }
}
