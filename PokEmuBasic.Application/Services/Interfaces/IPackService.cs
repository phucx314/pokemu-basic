using PokEmuBasic.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services.Interfaces
{
    public interface IPackService
    {
        Task<IEnumerable<OpenCardResponse>> OpenPackAsync(int packId);
    }
}
