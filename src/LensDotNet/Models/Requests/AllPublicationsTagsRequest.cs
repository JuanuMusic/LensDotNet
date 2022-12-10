namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AllPublicationsTagsRequest : BasePagingModel
    {
        public TagSortCriteria Sort { get; set; }
        public string Source { get; set; }
    }
}