namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeedRequest : BasePagingModel
    {
        public string ProfileId { get; set; }
        public List<FeedEventItemType> FeedEventItemTypes { get; set; }
        public List<string> Sources { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
    }
}