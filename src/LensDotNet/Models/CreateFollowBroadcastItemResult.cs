namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateFollowBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateFollowEIP712TypedData TypedData { get; set; }
    }
}