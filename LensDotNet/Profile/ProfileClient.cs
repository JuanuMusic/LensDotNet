using LensDotNet.Authentication;
using LensDotNet.Client.Fragments;
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
    }
}
