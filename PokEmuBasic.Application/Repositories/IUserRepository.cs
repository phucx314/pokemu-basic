using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsUsernameAsync(string username);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByIdAsync(int id);
    }
}
