using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = default!;
        public string HashedPassword { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int CoinBalance { get; set; }
        public string Avatar { get; set; } = default!;

        public ICollection<UserCard> UserCards { get; set; } = [];
        public ICollection<UserSession> UserSessions { get; set; } = [];
    }
}
