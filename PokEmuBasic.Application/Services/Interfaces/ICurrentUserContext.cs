using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services.Interfaces
{
    public interface ICurrentUserContext
    {
        public int? UserId { get; } // tra ve null neu ko ai dang nhap
        public int? SessionId { get; }
    }
}
