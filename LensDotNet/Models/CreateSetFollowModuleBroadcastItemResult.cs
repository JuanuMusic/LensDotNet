namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetFollowModuleBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateSetFollowModuleEIP712TypedData TypedData { get; set; }
    }
}