using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Domain.Common.Constants
{
    public static class PaginationConstants
    {
        public const int PageSize = 16;
        public const int PageStart = 1;
        public const string DefaultSortKey = "Id";

        public const string ASCENDING = "ASC";
        public const string DESCENDING = "DESC";
    }
}
