namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfilePublicationRevenueQueryRequest : BasePagingModel
    {
        public string ProfileId { get; set; }
        public List<string> Sources { get; set; }
        public List<PublicationTypes> Types { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
    }
}