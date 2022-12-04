namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReactionEvent
    {
        public Profile Profile { get; set; }
        public ReactionTypes Reaction { get; set; }
        public string Timestamp { get; set; }
    }
}