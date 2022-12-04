namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial record ProfileSearchResult()
    {
        public List<Profile> Items { get; set; } = default!;
        public PaginatedResultInfo PageInfo { get; set; } = default!;
        public SearchRequestTypes Type { get; set; } = default!;
    }
}   