using LensDotNet.Authentication;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client
{
    public abstract class BaseClient : LensGQLClient
    {
        internal AuthenticationClient? _authentication;

        public BaseClient(LensConfig config, AuthenticationClient? authentication = null) :
            base(new HttpClient())
        {
            base.HttpClient.BaseAddress = config.GqlEndpoint;
            RefreshAuthentication(authentication).Wait();
        }

        public async Task RefreshAuthentication(AuthenticationClient? newClient = null)
        {
            if(newClient != null)
            {
                _authentication = newClient;
            }

            if (_authentication != null)
                await RefreshAuthHeaders();
        }

        private async Task RefreshAuthHeaders()
        {
            if (_authentication != null && await _authentication.IsAuthenticated())
                base.HttpClient.DefaultRequestHeaders.Authorization = await _authentication.GetRequestHeader();
        }
    }
}
