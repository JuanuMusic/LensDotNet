using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroQL;

namespace LensDotNet.Client.Fragments.Publication
{
    public static class PublicationFragmentsBuildExtensions
    {
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
        public static PostFragment AsFragment(this Post post)
            => new PostFragment
            {
                CollectedBy = post.CollectedBy(w => w.AsFragment()),
                CollectNftAddress = post.CollectNftAddress,
                CreatedAt = post.CreatedAt,
                DataAvailabilityProofs = post.DataAvailabilityProofs,
                HasCollectedByMe = post.HasCollectedByMe(null),
                Hidden = post.Hidden,
                Id = post.Id,
                IsDataAvailability = post.IsDataAvailability,
                IsGated = post.IsGated,
                Metadata = post.Metadata(m => m.AsFragment()),
                Mirrors = post.Mirrors(null),
                Profile = post.Profile(p => p.AsProfileFragment()),
                Reaction = post.Reaction(null),
                Stats = post.Stats(s => s.AsFragment())
            };

    }
}
