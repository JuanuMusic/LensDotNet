namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ExploreProfilesRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string Timestamp { get; set; }
        public ProfileSortCriteria SortCriteria { get; set; }
        public List<CustomFiltersTypes> CustomFilters { get; set; }
    }
}