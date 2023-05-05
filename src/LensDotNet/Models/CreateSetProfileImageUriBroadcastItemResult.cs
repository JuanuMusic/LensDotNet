namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileImageUriBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateSetProfileImageUriEIP712TypedData TypedData { get; set; }
    }
}