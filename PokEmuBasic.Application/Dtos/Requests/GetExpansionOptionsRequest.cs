using PokEmuBasic.Domain.Common.Constants;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Requests
{
    public class GetExpansionOptionsRequest : QueryRequest
    {
        public string? SearchKey { get; set; }

        public override string SortBy { get; set; } = nameof(Expansion.ReleaseDate);
        public override string Direction { get; set; } = PaginationConstants.DESCENDING;
    }
}
