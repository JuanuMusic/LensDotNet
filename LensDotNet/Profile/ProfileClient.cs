using LensDotNet.Authentication;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using LensDotNet.Config;

namespace LensDotNet.Client
{
    public class ProfileClient
    {
        private readonly AuthenticationClient? _authentication;
        private readonly LensGQLClient _client;

        public ProfileClient(LensConfig config, AuthenticationClient? authentication = null)
        {
            _authentication = authentication;
            var httpClient = new HttpClient();
            httpClient.BaseAddress = config.GqlEndpoint;
            _client = new LensGQLClient(httpClient);
        }

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
            var resp = await _client.Query(request, static (i, o) => o.Profile<ProfileFragment>(i.Input, output => output.AsProfileFragment() ));
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

            var resp = await _client.Query(req, static (i, output) => output.RecommendedProfiles(i.Input, p => p.AsProfileFragment()));
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

            return resp.Data;
        }
    }
}
