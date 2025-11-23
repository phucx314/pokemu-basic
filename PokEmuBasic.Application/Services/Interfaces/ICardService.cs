using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services.Interfaces
{
    public interface ICardService
    {
        Task<(List<GetCardListResponse> cards, int total, string? expansionName)> GetCardListByExpansionAsync(GetCardListRequest request);
    }
}
