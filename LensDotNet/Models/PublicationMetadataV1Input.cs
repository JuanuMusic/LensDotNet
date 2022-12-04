namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataV1Input
    {
        public string Version { get; set; }
        public string Metadata_id { get; set; }
        public string AppId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string External_url { get; set; }
        public PublicationSignatureContextInput SignatureContext { get; set; }
        public string Name { get; set; }
        public List<MetadataAttributeInput> Attributes { get; set; }
        public string Image { get; set; }
        public string ImageMimeType { get; set; }
        public List<PublicationMetadataMediaInput> Media { get; set; }
        public string Animation_url { get; set; }
    }
}