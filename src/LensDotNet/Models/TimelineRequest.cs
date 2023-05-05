namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TimelineRequest : BasePagingModel
    {
        public string ProfileId { get; set; }
        public List<string> Sources { get; set; }
        public List<TimelineType> TimelineTypes { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
    }
}