namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateUnfollowBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateBurnEIP712TypedData TypedData { get; set; }
    }
}