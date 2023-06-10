using LensDotNet.Client;
using LensDotNet.Client.Authentication.Adapters;
using LensDotNet.Config;
using System;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public interface IAuthenticationClient
    {
        public Task<AuthChallengeResult?> GenerateChallenge(string address);
        public Task Authenticate(string address, string signature);
        public Task<bool> IsAuthenticated();
    }

    public class AuthenticationClient : IAuthenticationClient
    {
        public event EventHandler OnAuthChanged;
        private readonly ILensAuthenticationApi _api;
        private CredentialsAdapter _credentials;
        public string AccessToken { get => _credentials != null ? _credentials.AccessToken : string.Empty; }

        public AuthenticationClient(LensConfig config)
            => _api = new LensAuthenticationApi(config.GqlEndpoint);

        public async Task Authenticate(string address, string signature)
        {
            var credentials = await _api.Authenticate(address, signature);
            _credentials = new CredentialsAdapter(credentials);
            if (OnAuthChanged != null) OnAuthChanged.Invoke(this, new EventArgs());
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
                var newCredentials = await _api.Refresh(_credentials.RefreshToken);
                if (newCredentials == null)
                    return false;

                _credentials = new CredentialsAdapter(newCredentials);
                if (OnAuthChanged != null) OnAuthChanged.Invoke(this, new EventArgs());
                return true;
            }

            return false;
        }
    }
}