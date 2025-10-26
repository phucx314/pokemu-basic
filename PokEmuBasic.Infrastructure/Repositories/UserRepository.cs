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
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> Queryable => _dbContext.Users.AsQueryable();

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<User> AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);

            return user;
        }

        public Task<IEnumerable<User>> AddRangeAsync(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsUsernameAsync(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}
