using LensDotNet.Client.Fragments.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroQL;

namespace LensDotNet.Client.Fragments.Profile
{
    public static class ProfileFragmentBuildExtensions
    {
        [GraphQLFragment]
        public static PaginatedResult<ProfileFragment> AsPaginatedResult<T>(this PaginatedProfileResult resultInfo)
        {
            return new PaginatedResult<ProfileFragment>
            {
                PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = resultInfo.Items(itm => itm.AsProfileFragment())
            };
        }

        [GraphQLFragment]
        public static ProfileFragment AsProfileFragment(this Client.Profile profile)
        {
            return new ProfileFragment
            {
                Id = profile.Id,
                Bio = profile.Bio,
                Handle = profile.Handle,
                Interests = profile.Interests,
                IsDefault = profile.IsDefault,
                Name = profile.Name,
                OwnedBy = profile.OwnedBy
            };
        }

        [GraphQLFragment]
        public static ProfileStatsFragment AsProfileStatsFragment(this ProfileStats profileStats, Sources[] sources)
        {
            return new ProfileStatsFragment
            {
                TotalComments = profileStats.TotalComments,
                TotalCollects = profileStats.TotalCollects,
                TotalFollowers = profileStats.TotalFollowers,
                TotalFollowing = profileStats.TotalFollowing,
                TotalMirrors = profileStats.TotalMirrors,
                TotalPosts = profileStats.TotalPosts,
                TotalPublications = profileStats.TotalPublications,
                CommentsTotal = profileStats.CommentsTotal(sources),
                PostsTotal = profileStats.PostsTotal(sources),
                MirrorsTotal = profileStats.MirrorsTotal(sources),
                PublicationsTotal = profileStats.PublicationsTotal(sources)
            };
        }
    }
}
