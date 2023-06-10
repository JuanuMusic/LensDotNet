using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Fragments.Publication
{
    public record PublicationFragment
    {
        public PostFragment? Post { get; set; }
        public MirrorFragment Mirror { get; set; }
        public CommentFragment? Comment { get; set; }
    }

    public record SimplePublicationStatsFragment
    {
        public int TotalAmountOfMirrors { get; set; }
        public int TotalAmountOfCollects { get; set; }
        public int TotalAmountOfComments { get; set; }
        public int TotalUpvotes { get; set; }
        public int TotalDownvotes { get; set; }
    }

    public record MediaFragment
    {
        public string? AltTag { get; set; }
        public string? Cover { get; set; }
        public string? MimeType { get; set; }
        public string Url { get; set; }
    }

    public record MediaSetFragment
    {
        public MediaFragment Original { get; set; }
    }

    public record MetadataAttributeOutputFragment {
        public string? TraitType { get; set; }
        public string? Value { get; set; }
    }

    public record MetadataFragment
    {
        public Url? AnimatedUrl { get; set; }
        public Markdown? Content { get; set; }
        public PublicationContentWarning? ContentWarning { get; set; }
        public Markdown? Description { get; set; }
        public Url? Image { get; set; }
        public Locale? Locale { get; set; }
        public PublicationMainFocus? MainContentFocus { get; set; }
        public string? Name { get; set; }
        public string[] Tags { get; set; } = new string[0];
        public MediaSetFragment[] Media { get; set; } = new MediaSetFragment[0];
        public MetadataAttributeOutputFragment[] Attributes { get; set; } = new MetadataAttributeOutputFragment[0];
    }

    public record BasePublicationFragment
    {
        public InternalPublicationId Id { get; set; }
        public ContractAddress CollectNftAddress { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public bool Hidden { get; set; }
        public bool IsGated { get; set; }
        public bool IsDataAvailability { get; set; }
        public string? DataAvailabilityProofs { get; set; }
        public ReactionTypes? Reaction { get; set; }
        public bool HasCollectedByMe { get; set; }
        public InternalPublicationId[] Mirrors { get; set; }
        public SimplePublicationStatsFragment Stats { get; set; }
        public MetadataFragment Metadata { get; set; }
        public ProfileFragment Profile { get; set; }
        public WalletFragment CollectedBy { get; set; }
        public object CollectModule { get; set; }
        public object ReferenceModule { get; set; }
        public bool CanComment { get; set; }
        public bool CanMirror { get; set; }
    }

    public record PostFragment : BasePublicationFragment
    {}

    public record CommentFragment : BasePublicationFragment { }

    public record MirrorFragment {
        public InternalPublicationId Id { get; set; }
    }

    public record PublicationForSaleFragment
    {
        public CommentFragment Comment { get; set; }
        public PostFragment Post { get; set; }
    }
    
    public record PublicationMetadataStatusFragment { 
        public PublicationMetadataStatusType Status { get; set; }
        public string Reason { get; set; }
    }
}
