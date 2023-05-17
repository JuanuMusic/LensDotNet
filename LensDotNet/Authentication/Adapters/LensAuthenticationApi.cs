
namespace LensDotNet.Client.Authentication.Adapters
{
    public interface ILensAuthenticationApi
    {
        public Task<AuthChallengeResult> Challenge(string address);
        public Task<bool?> Verify(string accessToken);
        public Task<AuthenticationResult?> Authenticate(string accessToken, string signature);
        public Task<AuthenticationResult?> Refresh(string refreshToken);
    }


    public class LensAuthenticationApi : ILensAuthenticationApi
    {
        private LensGQLClient _client;
        //private readonly GraphQLHttpClient _client;

        public LensAuthenticationApi(Uri gqlEndpoint)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = gqlEndpoint;
            _client = new LensGQLClient(httpClient);
        }

        public async Task<AuthenticationResult?> Authenticate(string address, string signature)
        {
            var request = new { Input = new SignedAuthChallenge { Address = address, Signature = signature } };
            var resp = await _client.Mutation(request, static (i,o) => o.Authenticate(i.Input, o => new AuthenticationResult  { AccessToken = o.AccessToken, RefreshToken = o.RefreshToken }));
            return resp.Data;
        }

        public async Task<AuthChallengeResult> Challenge(string address)
        {
            var request = new { Input = new ChallengeRequest() { Address = address } };
            var result = await _client.Query(request, static (i, o) => o.Challenge(i.Input, output => new AuthChallengeResult { Text = output.Text }));
            return result.Data;
        }

        public async Task<AuthenticationResult?> Refresh(string refreshToken)
        {
            var request = new { Input = new RefreshRequest { RefreshToken = refreshToken } };
            var resp = await _client.Mutation(request, static (i, o) => o.Refresh(i.Input, o => new AuthenticationResult { AccessToken = o.AccessToken, RefreshToken = o.RefreshToken}));
            return resp.Data;
            //var request = new GraphQLRequest(AuthQueries.Refresh, new { refreshToken = refreshToken });
            //var result = await _client.SendQueryAsync<ApiResponse<AuthenticationCredentials>>(request);

            //if (result == null) return null;
            //if (result.Errors != null && result.Errors.Length > 0)
            //{
            //    throw result.Errors.ToException();
            //}
            //return result.Data.Result;
        }

        public async Task<bool?> Verify(string accessToken)
        {
            var request = new { Input = new VerifyRequest() { AccessToken = accessToken } };
            var resp = await _client.Query(request, static (i, o) => o.Verify(i.Input));
            return resp.Data;
        }
    }
}
