namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SetDefaultProfileBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public SetDefaultProfileEIP712TypedData TypedData { get; set; }
    }
}