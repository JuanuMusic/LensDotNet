namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MetadataAttributeOutput
    {
        public PublicationMetadataDisplayTypes DisplayType { get; set; }
        public string TraitType { get; set; }
        public string Value { get; set; }
    }
}