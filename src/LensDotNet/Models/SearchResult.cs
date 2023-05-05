using System;
using System.Collections.Generic;

namespace LensDotNet.Models
{

    public partial record SearchResult
    {
        public record PublicationSearchResult(
            List<PublicationSearchResultItem> Items,
            PaginatedResultInfo PageInfo,
            SearchRequestTypes Type) : SearchResult;

        public record ProfileSearchResult(
            List<Profile> Items,
            PaginatedResultInfo PageInfo,
            SearchRequestTypes Type) : SearchResult;

        private SearchResult() { }
    }
}