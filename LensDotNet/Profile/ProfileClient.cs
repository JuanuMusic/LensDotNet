using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using LensDotNet.Authentication;
using LensDotNet.Client.Authentication;
using LensDotNet.Client.Models.Requests;
using LensDotNet.Client.Models.Responses;
using LensDotNet.Config;
using LensDotNet.Models.Auth;
using LensDotNet.Models.Profile;
using LensDotNet.Core;
using LensDotNet.Client.Profile.GQL;

namespace LensDotNet.Client.Profile
{
    public class ProfileClient
    {
        private readonly AuthenticationClient? _authentication;
        private readonly GraphQLHttpClient _client;

        public ProfileClient(LensConfig config, AuthenticationClient? authentication = null)
        {
            _authentication = authentication;
            _client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri(config.GqlEndpoint),
            }, new NewtonsoftJsonSerializer());
        }

        public async Task<ProfileFragment> Fetch(SingleProfileRequest profileRequest, string? observerId = null)
        {
            var request = new GraphQLRequest(ProfileQueries.Profile, new { request = profileRequest });
            var result = await _client.SendQueryAsync<ApiResponse<ProfileFragment>>(request);
            if (result == null) return null;
            if (result.Errors != null && result.Errors.Length > 0)
            {
                throw result.Errors.ToException();
            }
            return result.Data.Result;
        }
    }
}
