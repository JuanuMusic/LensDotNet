using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Fragments.Common
{
    public record CommonPaginatedResultInfo
    {
        public string? Prev { get; set; }
        public string? Next { get; set; }
    }

    public record PaginatedResult<T>
    {
        public T[] Items { get; set; }
        public CommonPaginatedResultInfo PageInfo { get; set; }
    }
}
