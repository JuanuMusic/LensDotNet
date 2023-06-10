using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Config;
using System;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public class ProfileClient : BaseClient
    {

        public ProfileClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication) { }

        public async Task<ProfileFragment> Fetch(SingleProfileQueryRequest profileRequest, string? observerId = null)
        {
            var resp = await _client.Query(new { Input = profileRequest }, static (i, o) => o.Profile(i.Input, output => output.AsFragment()));
            
            if (resp.Errors != null && resp.Errors.Length > 0)
                throw resp.Errors.ToException("An unhandled exception occurred while fetching single profile");
            
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
            var resp = await _client.Query(request, static (i, o) => o.Profile<ProfileStatsFragment>(i.Input, output => output.Stats<ProfileStatsFragment>(stats => stats.AsProfileStatsFragment(i.Sources))));
            return resp.Data;
        }

        public async Task<PaginatedResult<ProfileFragment>> FetchAll(ProfileQueryRequest profileRequest)
        {
            var request = new
            {
                Input = profileRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.Profiles(i.Input,
                    output => output.AsPaginatedResult<ProfileFragment>()));
            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching all profiles");
            }
            return resp.Data;
        }

        public async Task<ProfileFragment[]> AllRecommended(RecommendedProfileOptions? options)
        {
            var req = new
            {
                Input = options ?? new RecommendedProfileOptions()
            };

            var resp = await _client.Query(req, static (i, output) => output.RecommendedProfiles(i.Input, p => p.AsFragment()));
            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching all recommended profiles");
            }
            return resp.Data;
        }

        public async Task<PaginatedResult<ProfileFragment>> MutualFollowers(MutualFollowersProfilesQueryRequest mutualFollowersRequest)
        {
            var request = new
            {
                Input = mutualFollowersRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.MutualFollowersProfiles(i.Input,
                    output => output.AsPaginatedResult<ProfileFragment>()));

            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching mutual followers");
            }
            return resp.Data;
        }

        public async Task<DoesFollowFragment[]> DoesFollow(DoesFollowRequest doesFollowRequest)
        {
            var request = new
            {
                Input = doesFollowRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.DoesFollow(i.Input,
                    output => output.AsDoesFollowFragment()));
            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching DoesFollow");
            }
            return resp.Data;
        }

        public async Task<PaginatedResult<FollowingFragment>> AllFollowing(FollowingRequest followingRequest)
        {
            var request = new
            {
                Input = followingRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.Following(i.Input,
                    output => output.AsPaginatedResult<FollowingFragment>()));

            return resp.Data;
        }

        public async Task<PaginatedResult<FollowerFragment>> AllFollowers(FollowersRequest followersRequest)
        {
            var request = new
            {
                Input = followersRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.Followers(i.Input,
                    output => output.AsPaginatedResult()));

            return resp.Data;
        }

        public async Task<FollowerNftOwnedTokenIdsFragment> FollowerNftOwnedTokenIds(FollowerNftOwnedTokenIdsRequest followerNftOwnedTokenIdsRequest)
        {
            var request = new
            {
                Input = followerNftOwnedTokenIdsRequest
            };
            var resp = await _client.Query(request,
                static (i, o) => o.FollowerNftOwnedTokenIds(i.Input,
                    output => output.AsFragment()));

            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw resp.Errors.ToException("An unhandled exception occurred while fetching FollowerNftOwnedTokenIds");
            }
            return resp.Data;
        }

        public async Task<RelayResultFragment> CreateProfile(CreateProfileRequest createProfileRequest)
        {

            var req = new
            {
                Input = createProfileRequest
            };

            if (_authentication == null || !await _authentication.IsAuthenticated())
                throw new Exception("Client not authenticated.");

            var resp = await _client.Mutation(req, static (i, o) => o.CreateProfile(i.Input, output => output.AsFragment()));
            if (resp.Errors != null && resp.Errors.Length > 0)
                throw resp.Errors.ToException("An unhandled exception occurred while creating post via dispatcher");

            return resp.Data;
        }


    }
}
