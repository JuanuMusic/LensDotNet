namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateCollectBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateCollectEIP712TypedData TypedData { get; set; }
    }
}