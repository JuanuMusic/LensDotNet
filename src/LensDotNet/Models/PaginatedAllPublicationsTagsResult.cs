namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedAllPublicationsTagsResult
    {
        public List<TagResult> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}