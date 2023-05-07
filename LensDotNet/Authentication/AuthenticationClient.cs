using LensDotNet.Client.Authentication.Adapters;
using LensDotNet.Config;
using LensDotNet.Models.Auth;
using System.Net.Sockets;

namespace LensDotNet.Authentication
{
    public interface IAuthenticationClient
    {
        public Task<Challenge?> GenerateChallenge(string address);
        public Task Authenticate(string address, string signature);
        public Task<bool> IsAuthenticated();
    }

    public class AuthenticationClient : IAuthenticationClient
    {
        private readonly ILensAuthenticationApi _api;
        private CredentialsAdapter _credentials;

        public AuthenticationClient(LensConfig config)
            => _api = new LensAuthenticationApi(new Uri(config.GqlEndpoint));

        public async Task Authenticate(string address, string signature)
        {
            var credentials = await _api.Authenticate(address, signature);
            _credentials = new CredentialsAdapter(credentials);
        }

        public async Task<Challenge?> GenerateChallenge(string address)
            => await _api.Challenge(address);

        public async Task<bool> IsAuthenticated()
        {
            if (_credentials == null)
                return false;

            if (!_credentials.ShouldRefresh())
                return true;

            if(_credentials.CanRefresh())
            {
                var newCredentials = await _api.Refresh(_credentials.RefreshToken);
                if (newCredentials == null) 
                    return false;
                
                _credentials = new CredentialsAdapter(newCredentials);
                return true;
            }

            return false;
        }
    }
}