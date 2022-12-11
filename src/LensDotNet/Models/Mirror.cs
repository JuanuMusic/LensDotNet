namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Mirror
    {
        public string Id { get; set; }
        public Profile Profile { get; set; }
        public PublicationStats Stats { get; set; }
        public MetadataOutput Metadata { get; set; }
        public string OnChainContentURI { get; set; }
        public string CreatedAt { get; set; }
        public CollectModule CollectModule { get; set; }
        public ReferenceModule ReferenceModule { get; set; }
        public string AppId { get; set; }
        public bool Hidden { get; set; }
        public string CollectNftAddress { get; set; }
        public bool IsGated { get; set; }
        public MirrorablePublication MirrorOf { get; set; }
        public ReactionTypes Reaction { get; set; }
        public bool HasCollectedByMe { get; set; }
        public CanCommentResponse CanComment { get; set; }
        public CanMirrorResponse CanMirror { get; set; }
        public CanDecryptResponse CanDecrypt { get; set; }
    }
}