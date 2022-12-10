namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfilePublicationsForSaleRequest : BasePagingModel
    {
        public string ProfileId { get; set; }
        public List<string> Sources { get; set; }
        public PublicationMetadataFilters Metadata { get; set; }
    }
}