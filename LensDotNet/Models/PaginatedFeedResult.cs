namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedFeedResult
    {
        public List<FeedItem> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}