namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MetadataOutput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public MediaSet Cover { get; set; }
        public List<MediaSet> Media { get; set; }
        public List<MetadataAttributeOutput> Attributes { get; set; }
        public string Locale { get; set; }
        public List<string> Tags { get; set; }
        public PublicationContentWarning ContentWarning { get; set; }
        public PublicationMainFocus MainContentFocus { get; set; }
        public string AnimatedUrl { get; set; }
        public EncryptionParamsOutput EncryptionParams { get; set; }
    }
}