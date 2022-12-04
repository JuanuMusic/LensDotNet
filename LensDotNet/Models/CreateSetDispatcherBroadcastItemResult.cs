namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetDispatcherBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateSetDispatcherEIP712TypedData TypedData { get; set; }
    }
}