using LensDotNet.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Config;

namespace LensDotNet.Client
{
    public class ProfileClient : BaseClient
    {
        
        public ProfileClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication){}

        public async Task<ProfileFragment> Fetch(SingleProfileQueryRequest profileRequest, string? observerId = null)
        {
            var request = new
            {
                Input = new SingleProfileQueryRequest
                {
                    Handle = profileRequest.Handle,
                    ProfileId = profileRequest.ProfileId
                }
            };
            var resp = await this.Query(request, static (i, o) => o.Profile<ProfileFragment>(i.Input, output => output.AsProfileFragment() ));
            return resp.Data;
        }

        public async Task<ProfileStatsFragment> Stats(SingleProfileQueryRequest profileRequest, Sources[] sources)
        {
            var request = new
            {
                Input = new SingleProfileQueryRequest
                {
                    Handle = profileRequest.Handle,
                    ProfileId = profileRequest.ProfileId
                },
                Sources = sources
            };
            var resp = await this.Query(request, static (i, o) => o.Profile<ProfileStatsFragment>(i.Input, output => output.Stats<ProfileStatsFragment>(stats => stats.AsProfileStatsFragment(i.Sources))));
            return resp.Data;
        }

        public async Task<PaginatedResult<ProfileFragment>> FetchAll(ProfileQueryRequest profileRequest)
        {
            var request = new
            {
                Input = profileRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.Profiles<PaginatedResult<ProfileFragment>>(i.Input,
                    output => output.AsPaginatedResult<ProfileFragment>()));

            return resp.Data;
        }

        public async Task<ProfileFragment[]> AllRecommended(RecommendedProfileOptions? options)
        {
            var req = new
            {
                Input = options
            };

            var resp = await this.Query(req, static (i, output) => output.RecommendedProfiles(i.Input, p => p.AsProfileFragment()));
            return resp.Data;
        }

        public async Task<PaginatedResult<ProfileFragment>> MutualFollowers(MutualFollowersProfilesQueryRequest mutualFollowersRequest)
        {
            var request = new
            {
                Input = mutualFollowersRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.MutualFollowersProfiles(i.Input,
                    output => output.AsPaginatedResult<ProfileFragment>()));

            return resp.Data;
        }

        public async Task<DoesFollowFragment[]> DoesFollow(DoesFollowRequest doesFollowRequest)
        {
            var request = new
            {
                Input = doesFollowRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.DoesFollow<DoesFollowFragment>(i.Input,
                    output => output.AsDoesFollowFragment()));

            return resp.Data;
        }

        public async Task<PaginatedResult<FollowingFragment>> AllFollowing(FollowingRequest followingRequest)
        {
            var request = new
            {
                Input = followingRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.Following<PaginatedResult<FollowingFragment>>(i.Input,
                    output => output.AsPaginatedResult<FollowingFragment>()));

            return resp.Data;
        }

        public async Task<PaginatedResult<FollowerFragment>> AllFollowers(FollowersRequest followersRequest)
        {
            var request = new
            {
                Input = followersRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.Followers<PaginatedResult<FollowerFragment>>(i.Input,
                    output => output.AsPaginatedResult()));

            return resp.Data;
        }

        public async Task<FollowerNftOwnedTokenIdsFragment> FollowerNftOwnedTokenIds(FollowerNftOwnedTokenIdsRequest followerNftOwnedTokenIdsRequest)
        {
            var request = new
            {
                Input = followerNftOwnedTokenIdsRequest
            };
            var resp = await this.Query(request,
                static (i, o) => o.FollowerNftOwnedTokenIds(i.Input,
                    output => output.AsFragment()));

            return resp.Data;
        }
    }
}
