using PokEmuBasic.Domain.Common.Constants;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos.Requests
{
    public class GetCardListRequest : QueryRequest
    {
        public string? SearchKey { get; set; }

        public int? ExpansionId { get; set; }
        public string? ExpansionName { get; set; } // cái này chỉ để phục vụ trả res cho controller thôi

        public override string SortBy { get; set; } = nameof(Card.ExpansionIndex);
        public override string Direction { get; set; } = PaginationConstants.ASCENDING;
    }
}
