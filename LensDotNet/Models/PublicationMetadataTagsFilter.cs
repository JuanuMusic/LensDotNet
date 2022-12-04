namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataTagsFilter
    {
        public List<string> OneOf { get; set; }
        public List<string> All { get; set; }
    }
}