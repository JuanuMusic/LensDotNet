namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public record PublicationSearchResult()
    {
        public List<PublicationSearchResultItem> Items { get; set; } = default!;
        public PaginatedResultInfo PageInfo { get; set; } = default!;
        public SearchRequestTypes Type { get; set; } = default!;
    }
}