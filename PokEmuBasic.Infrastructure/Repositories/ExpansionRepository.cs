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

        public async Task<(IEnumerable<Expansion> expansionOptions, int total)> GetExpansionsOptionsAsync(GetExpansionOptionsRequest request)
        {
            // common query
            var query = _dbContext.Expansions
                .AsNoTracking();

            // search query
            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                var searchKey = request.SearchKey.Trim().ToLower();

                query = query.Where(ex =>
                    ex.ExpansionName.ToLower().Contains(searchKey) ||
                    ex.ExpansionCode.ToLower().Contains(searchKey)
                );
            }

            // get total
            var total = await query.CountAsync();

            // apply sorting
            query = query.ApplySorting(request.SortBy, request.Direction);

            // pagination
            var expansionOptions = await query
                .WithoutDeleted()
                .Skip((request.CurrentPage - 1) * request.PageSize)
                .Take(request.PageSize) // 16
                .ToListAsync();

            return (expansionOptions, total);
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
