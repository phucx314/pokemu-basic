using Microsoft.EntityFrameworkCore;
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
    public class ExpansionRepository : IExpansionRepository
    {
        private readonly DatabaseContext _dbContext;

        public ExpansionRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Expansion> Queryable => _dbContext.Expansions.AsQueryable();

        public IUnitOfWork UnitOfWork => _dbContext;

        public Task<Expansion> AddAsync(Expansion entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expansion>> AddRangeAsync(IEnumerable<Expansion> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expansion entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Expansion> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expansion>> GetExpansionsOptionsAsync()
        {
            var expansionOptions = await _dbContext.Expansions
               .WithoutDeleted()
               .OrderByDescending(ex => ex.ReleaseDate)
               .Take(25)
               .ToListAsync();

            return expansionOptions;
        }

        public Task UpdateAsync(Expansion entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(IEnumerable<Expansion> entities)
        {
            throw new NotImplementedException();
        }
    }
}
