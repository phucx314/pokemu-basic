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
    public class PackRepository : IPackRepository
    {
        private readonly DatabaseContext _dbContext;

        public PackRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Pack> Queryable => _dbContext.Packs.AsQueryable();

        public IUnitOfWork UnitOfWork => _dbContext;

        public Task<Pack> AddAsync(Pack entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pack>> AddRangeAsync(IEnumerable<Pack> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Pack entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<Pack> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pack?>> GetAllPacksAsync()
        {
            var allPacks = _dbContext.Packs
                .WithoutDeleted()
                .OrderBy(p => p.CreatedAt)
                .ToListAsync();

            return await allPacks;
        }

        public async Task<IEnumerable<Pack?>> GetAllAvailablePacksAsync()
        {
            var availablePacks = _dbContext.Packs
                .WithoutDeleted()
                .Where(p => p.GlobalQuantity > 0)
                .OrderBy(p => p.CreatedAt)
                .ToListAsync();

            return await availablePacks;
        }

        public async Task<IEnumerable<PackRarityDropRate>> GetDropRatesAsync(int packId)
        {
            var dropRates = _dbContext.PackRarityDropRates
                // can them without deleted
                .Where(pdr => pdr.PackId == packId)
                .ToListAsync();

            return await dropRates;
        }

        public async Task<Pack?> GetPackByIdAsync(int packId)
        {
            var pack = _dbContext.Packs
                .WithoutDeleted()
                .FirstOrDefaultAsync(p => p.Id == packId);

            return await pack;
        }

        public async Task UpdateAsync(Pack pack)
        {
            _dbContext.Packs.Update(pack);
            await Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<Pack> entities)
        {
            throw new NotImplementedException();
        }
    }
}
