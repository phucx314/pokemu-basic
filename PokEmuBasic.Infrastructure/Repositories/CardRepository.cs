using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Domain.Entities;
using PokEmuBasic.Domain.Extensions;
using PokEmuBasic.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DatabaseContext _dbContext;

        public CardRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Card> Queryable => _dbContext.Cards.AsQueryable();

        public IUnitOfWork UnitOfWork => _dbContext;

        public Task<Card> AddAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> AddRangeAsync(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<(IEnumerable<Card?>? cards, int total)> GetCardListByExpansionAsync(GetCardListRequest request)
        {
            var query = _dbContext.Cards
                .AsNoTracking();

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                var searchKey = request.SearchKey.Trim().ToLower();

                query = query.Where(c =>
                    c.CardName.Contains(searchKey) // mấy cái HP với energy hay card type j j đó thì để filter riêng sau
                );
            }

            if (request.ExpansionId.HasValue)
            {
                query = query.Where(c => c.ExpansionId == request.ExpansionId.Value);
            }

            var total = await query.CountAsync();

            query = query.ApplySorting(request.SortBy, request.Direction);

            var cards = await query
                .WithoutDeleted()
                .Skip((request.CurrentPage - 1) * 25)
                .Take(25)
                .ToListAsync();

            return (cards, total);
        }

        public async Task<Card?> GetRandomCardByRarityAsync(int rarityId)
        {
            int countCardWithRarity = await _dbContext.Cards
                .CountAsync(c => c.RarityId == rarityId);

            if (countCardWithRarity == 0)
            {
                return null;
            }

            int randomIndex = Random.Shared.Next(0, countCardWithRarity); // 0 -> card count-1 (eg: 5000 cards => 0 -> 4999)

            var cardByRarityId = await _dbContext.Cards
                .Where(c => c.RarityId == rarityId)
                .OrderBy(c => c.Id) // sort by constant values - id - to ensure consistent ordering
                .Skip(randomIndex) // eg: skip (offset) 3125 first cards
                .Take(1) // take 1 next card. eg: 3126th card
                .FirstOrDefaultAsync();

            return cardByRarityId;
        }

        public Task UpdateAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }
    }
}
