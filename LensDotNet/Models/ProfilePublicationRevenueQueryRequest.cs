namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfilePublicationRevenueQueryRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string ProfileId { get; set; }
        public List<string> Sources { get; set; }
        public List<PublicationTypes> Types { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
    }
}