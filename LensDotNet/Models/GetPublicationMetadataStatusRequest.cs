namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class GetPublicationMetadataStatusRequest
    {
        public string PublicationId { get; set; }
        public string TxHash { get; set; }
        public string TxId { get; set; }
    }
}