namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationsQueryRequest : BasePagingModel
    {
        public string ProfileId { get; set; }
        public List<string> ProfileIds { get; set; }
        public List<PublicationTypes> PublicationTypes { get; set; }
        public string CommentsOf { get; set; }
        public List<string> Sources { get; set; }
        public string CollectedBy { get; set; }
        public List<string> PublicationIds { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
        public List<CustomFiltersTypes> CustomFilters { get; set; }
    }
}