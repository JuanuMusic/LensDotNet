namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ExploreProfilesRequest : BasePagingModel
    {
        public string? Timestamp { get; set; }
        public ProfileSortCriteria? SortCriteria { get; set; }
        public List<CustomFiltersTypes?>? CustomFilters { get; set; }
    }
}