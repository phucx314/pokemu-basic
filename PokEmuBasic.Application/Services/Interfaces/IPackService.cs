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
        Task<List<GetPacksResponse>> GetAllPacks();
        Task<List<GetPacksResponse>> GetAllAvailablePacks();
        Task<List<GetPacksResponse>> GetFeaturedPacksAsync(); // reuse the common dto
        Task<IEnumerable<OpenCardResponse>> OpenPackAsync(int packId);
    }
}
