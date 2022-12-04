namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataFilters
    {
        public string Locale { get; set; }
        public PublicationMetadataContentWarningFilter ContentWarning { get; set; }
        public List<PublicationMainFocus> MainContentFocus { get; set; }
        public PublicationMetadataTagsFilter Tags { get; set; }
    }
}