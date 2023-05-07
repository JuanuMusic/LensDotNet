using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using LensDotNet.Client.Models.Responses;
using LensDotNet.Core;
using LensDotNet.Models.Auth;

namespace LensDotNet.Client.Authentication.Adapters
{
    public interface ILensAuthenticationApi
    {
        public Task<Challenge?> Challenge(string address);
        public Task<bool?> Verify(string accessToken);
        public Task<AuthenticationCredentials?> Authenticate(string accessToken, string signature);
        public Task<AuthenticationCredentials?> Refresh(string refreshToken);
    }

    public class LensAuthenticationApi : ILensAuthenticationApi
    {
        private readonly GraphQLHttpClient _client;
        
        public LensAuthenticationApi(Uri gqlEndpoint)
        {
            _client = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = gqlEndpoint,
            }, new NewtonsoftJsonSerializer());
        }

        public async Task<AuthenticationCredentials?> Authenticate(string address, string signature)
        {
            var request = new GraphQLRequest(AuthQueries.Authenticate, new { address = address, signature = signature});
            var result = await _client.SendQueryAsync<ApiResponse<AuthenticationCredentials>>(request);
            if (result == null) return null;
            if (result.Errors != null && result.Errors.Length > 0)
            {
                throw result.Errors.ToException();
            }
            return result.Data.Result;
        }

        public async Task<Challenge?> Challenge(string address)
        {
            var request = new GraphQLRequest(AuthQueries.Challenge, new { address = address });
            var result = await _client.SendQueryAsync<ApiResponse<Challenge>>(request);
            if(result == null) return null;
            if(result.Errors != null && result.Errors.Length > 0)
            {
                throw result.Errors.ToException();
            }
            return result.Data.Result;
        }

        public async Task<AuthenticationCredentials?> Refresh(string refreshToken)
        {
            var request = new GraphQLRequest(AuthQueries.Refresh, new { refreshToken = refreshToken });
            var result = await _client.SendQueryAsync<ApiResponse<AuthenticationCredentials>>(request);

            if (result == null) return null;
            if (result.Errors != null && result.Errors.Length > 0)
            {
                throw result.Errors.ToException();
            }
            return result.Data.Result;
        }

        public async Task<bool?> Verify(string accessToken)
        {
            var request = new GraphQLRequest(AuthQueries.Verify, new { accessToken = accessToken });
            var result = await _client.SendQueryAsync<ApiResponse<bool>>(request);
            if (result == null) return null;
            if (result.Errors != null && result.Errors.Length > 0)
            {
                throw result.Errors.ToException();
            }
            return result.Data.Result;
        }
    }
}
