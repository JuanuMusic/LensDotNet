namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataV2Input : PublicationMetadataV1Input
    {
        public string Locale { get; set; }
        public List<string> Tags { get; set; }
        public PublicationContentWarning ContentWarning { get; set; }
        public PublicationMainFocus MainContentFocus { get; set; }
    }
}