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
    public class UserCardRepository : IUserCardRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserCardRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<UserCard> Queryable => _dbContext.UserCards.AsQueryable();

        public IUnitOfWork UnitOfWork => _dbContext;

        public Task<UserCard> AddAsync(UserCard entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserCard>> AddRangeAsync(IEnumerable<UserCard> userCards)
        {
            await _dbContext.UserCards.AddRangeAsync(userCards);
            return userCards;
        }

        public Task DeleteAsync(UserCard entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<UserCard> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserCard entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<UserCard> entities)
        {
            throw new NotImplementedException();
        }
    }
}
