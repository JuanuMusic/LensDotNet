namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateMirrorBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateMirrorEIP712TypedData TypedData { get; set; }
    }
}