namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreatePublicSetProfileMetadataURIRequest
    {
        public string ProfileId { get; set; }
        public string Metadata { get; set; }
    }
}