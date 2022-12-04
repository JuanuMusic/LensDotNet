namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AllPublicationsTagsRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public TagSortCriteria Sort { get; set; }
        public string Source { get; set; }
    }
}