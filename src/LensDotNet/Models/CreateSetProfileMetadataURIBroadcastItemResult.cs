namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileMetadataURIBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateSetProfileMetadataURIEIP712TypedData TypedData { get; set; }
    }
}