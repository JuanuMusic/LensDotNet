namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreatePostBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreatePostEIP712TypedData TypedData { get; set; }
    }
}