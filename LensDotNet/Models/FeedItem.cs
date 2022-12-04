namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeedItem
    {
        public FeedItemRoot Root { get; set; }
        public ElectedMirror ElectedMirror { get; set; }
        public List<MirrorEvent> Mirrors { get; set; }
        public List<CollectedEvent> Collects { get; set; }
        public List<ReactionEvent> Reactions { get; set; }
        public List<Comment> Comments { get; set; }
    }
}