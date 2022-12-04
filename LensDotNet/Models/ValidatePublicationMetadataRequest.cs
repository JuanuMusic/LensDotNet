namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ValidatePublicationMetadataRequest
    {
        public PublicationMetadataV1Input Metadatav1 { get; set; }
        public PublicationMetadataV2Input Metadatav2 { get; set; }
    }
}