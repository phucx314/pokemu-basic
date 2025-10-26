using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Repositories
{
    public interface IUserSessionRepository
    {
        Task AddAsync(UserSession session);

        IQueryable<UserSession> Queryable { get; }
        Task<UserSession?> GetByIdAsync(int sessionId);
        Task<UserSession?> GetByRefreshTokenAsync(string refreshToken);
        Task<bool> SessionExistsAsync(int sessionId);

        Task Update(UserSession session);

        Task DeleteByIdAsync(int sessionId);
        Task Delete(UserSession session);
        Task DeleteRange(IEnumerable<UserSession> sessions);
    }
}
