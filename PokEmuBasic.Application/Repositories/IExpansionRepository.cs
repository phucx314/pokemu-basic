using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Repositories
{
    public interface IExpansionRepository : IRepository<Expansion>
    {
        Task<IEnumerable<Expansion>> GetExpansionsOptionsAsync();
    }
}
