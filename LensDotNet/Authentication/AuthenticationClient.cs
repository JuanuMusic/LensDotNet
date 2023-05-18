using LensDotNet.Client;
using LensDotNet.Client.Authentication.Adapters;
using LensDotNet.Config;
using System.Net.Http.Headers;

namespace LensDotNet.Authentication
{
    public interface IAuthenticationClient
    {
        public Task<AuthChallengeResult?> GenerateChallenge(string address);
        public Task Authenticate(string address, string signature);
        public Task<bool> IsAuthenticated();
    }

    public class AuthenticationClient : IAuthenticationClient
    {
        private readonly ILensAuthenticationApi _api;
        private CredentialsAdapter _credentials;

        public AuthenticationClient(LensConfig config)
        {
            _api = new LensAuthenticationApi(config.GqlEndpoint);
        }

        public async Task Authenticate(string address, string signature)
        {
            var credentials = await _api.Authenticate(address, signature);
            _credentials = new CredentialsAdapter(credentials);
        }

        public async Task<AuthChallengeResult?> GenerateChallenge(string address)
            => await _api.Challenge(address);

        public async Task<bool> IsAuthenticated()
        {
            if (_credentials == null)
                return false;

            if (!_credentials.ShouldRefresh())
                return true;

            if (_credentials.CanRefresh())
            {
                return await RefreshCredentials();
            }

            return false;
        }

        private async Task<bool> RefreshCredentials()
        {
            var newCredentials = await _api.Refresh(_credentials.RefreshToken);
            if (newCredentials == null)
                return false;

            _credentials = new CredentialsAdapter(newCredentials);
            return true;
        }

        public async Task<AuthenticationHeaderValue?> GetRequestHeader()
        {
            if (_credentials == null)
                return null;

            if (!_credentials.ShouldRefresh())
                return BuildAuthorizationHeader(_credentials.AccessToken);

            if(_credentials.CanRefresh())
            {
                if(await RefreshCredentials())
                    return BuildAuthorizationHeader(_credentials.AccessToken);
            }

            return null;
        }

        private AuthenticationHeaderValue BuildAuthorizationHeader(string accessToken)
            => new AuthenticationHeaderValue("Bearer", accessToken);
    }
}