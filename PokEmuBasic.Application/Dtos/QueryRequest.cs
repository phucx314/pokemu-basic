using PokEmuBasic.Domain.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Dtos
{
    public class QueryRequest
    {
        public int PageSize { get; set; } = PaginationConstants.PageSize;
        public int CurrentPage { get; set; } = PaginationConstants.PageStart;
        public virtual string SortBy { get; set; } = PaginationConstants.DefaultSortKey;
        public virtual string Direction { get; set; } = PaginationConstants.DESCENDING;
    }
}
