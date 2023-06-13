using LensDotNet.Client;
using LensDotNet.Client.Fragments.Publication;
using System;
using System.Collections.Generic;
using System.Text;

namespace LensDotNet.Fragments.Feed
{
    public record FeedItemFragment
    {
        public PostFragment RootPost { get; set; }
        public CommentFragment RootComment { get; set; }
        public CommentFragment[] Comments { get; set; }
        public ElectedMirrorFragment ElectedMirror { get; set; }
        public MirrorEventFragment[] Mirrors { get; set; }
        public CollectedEventFragment[] Collects { get; set; }
        public ReactionEventFragment[] Reactions { get; set; }
    }
}
