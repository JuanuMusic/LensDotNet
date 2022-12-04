namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateCommentBroadcastItemResult
    {
        public string Id { get; set; }
        public string ExpiresAt { get; set; }
        public CreateCommentEIP712TypedData TypedData { get; set; }
    }
}