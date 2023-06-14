using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Gasless;
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
            => new PaginatedResult<ProfileFragment>
            {
                PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = resultInfo.Items(itm => itm.AsFragment())
            };

        [GraphQLFragment]
        public static PaginatedResult<FollowingFragment> AsPaginatedResult<T>(this PaginatedFollowingResult resultInfo)
           => new PaginatedResult<FollowingFragment>
           {
               Items = resultInfo.Items(itm => itm.AsFollowingFragment()),
               PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo())
           };

        [GraphQLFragment]
        public static PaginatedResult<ProfileFragment> AsPaginatedResult(this ExploreProfileResult resultInfo)
          => new PaginatedResult<ProfileFragment>
          {
              Items = resultInfo.Items(itm => itm.AsFragment()),
              PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo())
          };

        [GraphQLFragment]
        public static ProfileFragment AsFragment(this Client.Profile profile)
            => new ProfileFragment
            {
                Id = profile.Id,
                Bio = profile.Bio,
                Handle = profile.Handle,
                Interests = profile.Interests,
                IsDefault = profile.IsDefault,
                Name = profile.Name,
                OwnedBy = profile.OwnedBy,
                Dispatcher = profile.Dispatcher(d => d.AsFragment())
            };

        [GraphQLFragment]
        public static ProfileStatsFragment AsProfileStatsFragment(this ProfileStats profileStats, Sources[] sources)
            => new ProfileStatsFragment
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

        [GraphQLFragment]
        public static DoesFollowFragment AsDoesFollowFragment(this DoesFollowResponse response)
            => new DoesFollowFragment
            {
                FollowerAddress = response.FollowerAddress,
                IsFinalisedOnChain = response.IsFinalisedOnChain,
                ProfileId = response.ProfileId,
                Follows = response.Follows,
            };

        [GraphQLFragment]
        public static FollowingFragment AsFollowingFragment(this Following response)
           => new FollowingFragment { Profile = response.Profile(p => p.AsFragment()) };

        [GraphQLFragment]
        public static FollowerFragment AsFollowerFragment(this Follower response)
            => new FollowerFragment { Wallet = response.Wallet(w => w.AsFragment()) };

        [GraphQLFragment]
        public static PaginatedResult<FollowerFragment> AsPaginatedResult(this PaginatedFollowersResult result)
            => new PaginatedResult<FollowerFragment>
            {
                PageInfo = result.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = result.Items(itm => itm.AsFollowerFragment())
            };
        [GraphQLFragment]
        public static FollowerNftOwnedTokenIdsFragment AsFragment(this FollowerNftOwnedTokenIds result)
            => new FollowerNftOwnedTokenIdsFragment
            {
                FollowerNftAddress = result.FollowerNftAddress,
                TokenIds = result.TokensIds
            };
    }
}
    