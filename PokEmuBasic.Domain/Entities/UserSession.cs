using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string RefreshToken { get; set; } = default!;
        public DateTime RefreshTokenExpiryTime { get; set; }

        public string? DeviceName { get; set; }
        public string? IpAddress { get; set; }

        public DateTime? CreatedAt { get; set; } // ko ke thua tu BaseEntity vi ko can soft delete
        public DateTime? UpdatedAt { get; set; } // ko ke thua tu BaseEntity vi ko can soft delete

        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }

        public virtual User User { get; set; } = default!;
    }
}
