namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateToggleFollowBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateToggleFollowEIP712TypedData TypedData { get; set; }
    }
}