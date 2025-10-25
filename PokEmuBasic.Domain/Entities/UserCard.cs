using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class UserCard : BaseEntity
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
        public DateTime AcquiredAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = default!;
        public Card Card { get; set; } = default!;
    }
}
