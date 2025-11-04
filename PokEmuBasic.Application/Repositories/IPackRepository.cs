using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Repositories
{
    public interface IPackRepository : IRepository<Pack>
    {
        Task<IEnumerable<Pack?>> GetAllPacksAsync(); // get 1 list LOAI PACK chu ko phai la 1 list pack 
        Task<IEnumerable<Pack?>> GetAllAvailablePacksAsync(); // get 1 list LOAI PACK chu ko phai la 1 list pack 
        Task<IEnumerable<Pack?>> GetFeaturedPacksAsync();
        Task<Pack?> GetPackByIdAsync(int packId);
        Task<IEnumerable<PackRarityDropRate>> GetDropRatesAsync(int packId);
    }
}
