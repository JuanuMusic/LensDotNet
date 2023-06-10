using LensDotNet.Client.Authentication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public abstract class BaseClient
    {
        internal readonly AuthenticationClient? _authentication;
        internal readonly LensGraphQLClient _client;

        public BaseClient(LensConfig config, AuthenticationClient? authentication = null)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = config.GqlEndpoint;
            _client = new LensGraphQLClient(httpClient);
            _authentication = authentication;
            if (_authentication != null)
            {
                UpdateAuthHeader();
                _authentication.OnAuthChanged += _authentication_OnAuthChanged;
            }
        }

        private void _authentication_OnAuthChanged(object sender, EventArgs e)
            => UpdateAuthHeader();

        private void UpdateAuthHeader()
        {
            if (_authentication == null) return;

            string AUTH_HEADER = "Authorization";
            string token = $"Bearer {_authentication.AccessToken}";
            if (_client.HttpClient.DefaultRequestHeaders.Contains(AUTH_HEADER))
                _client.HttpClient.DefaultRequestHeaders.Remove(AUTH_HEADER);

            _client.HttpClient.DefaultRequestHeaders.Add(AUTH_HEADER, token);
        }
    }
}
