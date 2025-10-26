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
    public class UserSessionRepository : IUserSessionRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserSessionRepository(DatabaseContext databaseContext) => _dbContext = databaseContext;

        public async Task AddAsync(UserSession session)
        {
            await _dbContext.UserSessions.AddAsync(session);
        }

        public IQueryable<UserSession> Queryable => _dbContext.UserSessions.AsQueryable();

        public async Task Delete(UserSession session)
        {
            _dbContext.UserSessions.Remove(session);

            await Task.CompletedTask;
        }

        public async Task DeleteRange(IEnumerable<UserSession> sessions)
        {
            _dbContext.RemoveRange(sessions);

            await Task.CompletedTask;
        }

        public async Task<UserSession?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _dbContext.UserSessions.Include(s => s.User) // include luon thong tin User de lay duọc thong tin khi goi session.User (ko bi null)
                .FirstOrDefaultAsync(us => us.RefreshToken == refreshToken);
        }

        public async Task Update(UserSession session)
        {
            _dbContext.UserSessions.Update(session);

            await Task.CompletedTask;
        }

        public async Task<bool> SessionExistsAsync(int sessionId)
        {
            return await _dbContext.UserSessions.
                AnyAsync(us => us.Id == sessionId
                    && us.RefreshTokenExpiryTime > DateTimeOffset.UtcNow
                    && !us.IsRevoked); // nen dung Queryable ben service
        }

        public async Task DeleteByIdAsync(int sessionId)
        {
            var session = await _dbContext.UserSessions.FindAsync(sessionId);

            if (session != null)
            {
                _dbContext.UserSessions.Remove(session);
            }
        }

        public async Task<UserSession?> GetByIdAsync(int sessionId)
        {
            return await _dbContext.UserSessions.FindAsync(sessionId);
        }
    }
}
