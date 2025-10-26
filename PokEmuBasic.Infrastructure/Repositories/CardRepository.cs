using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Domain.Entities;
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

        public async Task<Card?> GetRandomCardByRarityAsync(int rarityId)
        {
            var cardByRarityId = await _dbContext.Cards
                .Where(c => c.RarityId == rarityId)
                .OrderBy(c => Guid.NewGuid()) // trick: random order
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
