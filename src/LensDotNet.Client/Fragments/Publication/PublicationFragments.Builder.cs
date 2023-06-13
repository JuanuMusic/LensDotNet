using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using System.Linq;
using ZeroQL;

namespace LensDotNet.Client.Fragments.Publication
{
    public static class PublicationFragmentsBuildExtensions
    {
        [GraphQLFragment]
        public static PaginatedResult<PublicationFragment> AsPaginatedResult<T>(this PaginatedPublicationResult resultInfo)
            => new PaginatedResult<PublicationFragment>
            {
                PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = resultInfo.Items(itm => itm.AsFragment())
            };

        [GraphQLFragment]
        public static SimplePublicationStatsFragment AsFragment(this PublicationStats stats)
            => new SimplePublicationStatsFragment
                {
                    TotalAmountOfCollects = stats.TotalAmountOfCollects,
                    TotalAmountOfComments = stats.TotalAmountOfComments,
                    TotalAmountOfMirrors = stats.TotalAmountOfMirrors,
                    TotalDownvotes = stats.TotalDownvotes,
                    TotalUpvotes = stats.TotalUpvotes,
                };

        [GraphQLFragment]
        public static MediaFragment AsFragment(this Media media)
            => new MediaFragment
            {
                AltTag = media.AltTag,
                Cover = media.Cover,
                MimeType = media.MimeType,
                Url = media.Url
            };

        [GraphQLFragment]
        public static MediaSetFragment AsFragment(this MediaSet mediaset)
            => new MediaSetFragment
            {
                Original = mediaset.Original(o => o.AsFragment())
            };

        [GraphQLFragment]
        public static MetadataAttributeOutputFragment AsFragment(this MetadataAttributeOutput metadataAttribute)
            => new MetadataAttributeOutputFragment
            {
                TraitType = metadataAttribute.TraitType,
                Value = metadataAttribute.Value,
            };

        [GraphQLFragment]
        public static MetadataFragment AsFragment(this MetadataOutput metadata)
            => new MetadataFragment
            {
                AnimatedUrl = metadata.AnimatedUrl,
                Attributes = metadata.Attributes(a => a.AsFragment()),
                Content = metadata.Content,
                ContentWarning = metadata.ContentWarning,
                Description = metadata.Description,
                Image = metadata.Image,
                Locale = metadata.Locale,
                MainContentFocus = metadata.MainContentFocus,
                Media = metadata.Media(m => m.AsFragment()),
                Name = metadata.Name,
                Tags = metadata.Tags,
            };

        [GraphQLFragment]
        public static PublicationFragment AsFragment(this Client.Publication p)
             => new PublicationFragment
             {
                 Post = p.On<Post>().Select(pp => ((Post)pp).AsFragment()),
                 Comment = p.On<Comment>().Select(pc => ((Comment)pc).AsFragment()),
                 Mirror = p.On<Mirror>().Select(pm => ((Mirror)pm).AsFragment())
             };

        [GraphQLFragment]
        public static CommentFragment AsFragment(this Comment comment)
            => new CommentFragment
            {
                CollectedBy = comment.CollectedBy(w => w.AsFragment()),
                CollectNftAddress = comment.CollectNftAddress,
                CreatedAt = comment.CreatedAt,
                DataAvailabilityProofs = comment.DataAvailabilityProofs,
                HasCollectedByMe = comment.HasCollectedByMe(null),
                Hidden = comment.Hidden,
                Id = comment.Id,
                IsDataAvailability = comment.IsDataAvailability,
                IsGated = comment.IsGated,
                Metadata = comment.Metadata(m => m.AsFragment()),
                //Mirrors = comment.Mirrors(null),
                Profile = comment.Profile(p => p.AsFragment()),
                Reaction = comment.Reaction(null),
                Stats = comment.Stats(s => s.AsFragment())
            };

        [GraphQLFragment]
        public static PostFragment AsFragment(this Post post)
            => new PostFragment
            {
                //CollectedBy = post.CollectedBy(w => w.AsFragment()),
                CollectNftAddress = post.CollectNftAddress,
                CreatedAt = post.CreatedAt,
                DataAvailabilityProofs = post.DataAvailabilityProofs,
                HasCollectedByMe = post.HasCollectedByMe(null),
                Hidden = post.Hidden,
                Id = post.Id,
                IsDataAvailability = post.IsDataAvailability,
                IsGated = post.IsGated,
                //Metadata = post.Metadata(m => m.AsFragment()),
                //Mirrors = post.Mirrors(null),
                //Profile = post.Profile(p => p.AsProfileFragment()),
                //Reaction = post.Reaction(null),
                //Stats = post.Stats(s => s.AsFragment())
            };

        [GraphQLFragment]
        public static MirrorFragment AsFragment(this Mirror mirror)
            => new MirrorFragment
            {
                Id = mirror.Id
            };

        [GraphQLFragment]
        public static PublicationForSaleFragment AsFragment(this PublicationForSale pubForSale)
            => new PublicationForSaleFragment
            {
                Post = pubForSale.On<Post>().Select(p => p.AsFragment()),
                Comment = pubForSale.On<Comment>().Select(c => c.AsFragment())
            };

        [GraphQLFragment]
        public static PaginatedResult<PublicationForSaleFragment> AsPaginatedResult(this PaginatedProfilePublicationsForSaleResult paginatedResult)
            => new PaginatedResult<PublicationForSaleFragment>
            {
                Items = paginatedResult.Items(i => i.AsFragment()),
                PageInfo = paginatedResult.PageInfo(pi => pi.AsCommonPaginatedResultInfo())
            };

        [GraphQLFragment]
        public static PaginatedResult<PublicationFragment> AsPaginatedResult<T>(this ExplorePublicationResult resultInfo)
            => new PaginatedResult<PublicationFragment>
            {
                PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = resultInfo.Items(itm => itm.AsFragment())
            };

        [GraphQLFragment]
        public static ElectedMirrorFragment AsFragment(this ElectedMirror electedMirror)
            => new ElectedMirrorFragment
            {
                MirrorId = electedMirror.MirrorId,
                Profile = electedMirror.Profile(p => p.AsFragment())
            };

        [GraphQLFragment]
        public static MirrorEventFragment AsFragment(this MirrorEvent @event)
            => new MirrorEventFragment
            {
                Timestamp = @event.Timestamp,
                Profile = @event.Profile(p => p.AsFragment())
            };

        [GraphQLFragment]
        public static CollectedEventFragment AsFragment(this CollectedEvent @event)
            => new CollectedEventFragment
            {
                Timestamp = @event.Timestamp,
                Profile = @event.Profile(p => p.AsFragment())
            };

        [GraphQLFragment]
        public static ReactionEventFragment AsFragment(this ReactionEvent @event)
            => new ReactionEventFragment
            {
                Reaction = @event.Reaction,
                Timestamp = @event.Timestamp,
                Profile = @event.Profile(p => p.AsFragment())
            };
    }
}
