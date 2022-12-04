namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ExplorePublicationRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string Timestamp { get; set; }
        public PublicationSortCriteria SortCriteria { get; set; }
        public List<string> Sources { get; set; }
        public List<PublicationTypes> PublicationTypes { get; set; }
        public bool? NoRandomize { get; set; }
        public List<string> ExcludeProfileIds { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
        public List<CustomFiltersTypes> CustomFilters { get; set; }
    }
}