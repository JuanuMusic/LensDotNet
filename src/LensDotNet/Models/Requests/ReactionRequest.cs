namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReactionRequest
    {
        public string ProfileId { get; set; }
        public ReactionTypes Reaction { get; set; }
        public string PublicationId { get; set; }
    }
}