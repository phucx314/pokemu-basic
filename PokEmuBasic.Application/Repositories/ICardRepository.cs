using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<Card?> GetRandomCardByRarityAsync(int rarityId);
        Task<(IEnumerable<Card?>? cards, int total)> GetCardListByExpansionAsync(GetCardListRequest request);
        Task<(IEnumerable<Card?>? cards, int total)> GetUserCardListByExpansionAsync(GetCardListRequest request, int? userId);
    }
}
