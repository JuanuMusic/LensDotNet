namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataStatus
    {
        public PublicationMetadataStatusType Status { get; set; }
        public string Reason { get; set; }
    }
}