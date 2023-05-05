namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class WhoReactedResult
    {
        public string ReactionId { get; set; }
        public ReactionTypes Reaction { get; set; }
        public string ReactionAt { get; set; }
        public Profile Profile { get; set; }
    }
}