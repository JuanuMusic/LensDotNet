using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Authentication.Adapters
{
    public class CredentialsAdapter
    {
        public readonly static TimeSpan TOKEN_EXPIRATION_THRESHOLD = TimeSpan.FromSeconds(30);
        
        private AuthenticationResult _credentials;
        public string RefreshToken { get => _credentials == null ? String.Empty : _credentials.RefreshToken; }
        
        public CredentialsAdapter(AuthenticationResult credentials)
            => _credentials = credentials;

        public bool ShouldRefresh()
        {
            if (_credentials == null || string.IsNullOrWhiteSpace(_credentials.AccessToken))
                return true;

            var now = DateTime.UtcNow;
            var expirationTime = GetTokenExpTime(_credentials.AccessToken);
            return now >= expirationTime - TOKEN_EXPIRATION_THRESHOLD;
        }

        internal bool CanRefresh()
        {
            var now = DateTime.UtcNow;
            var expirationTime = GetTokenExpTime(_credentials.AccessToken);
            return now < expirationTime - TOKEN_EXPIRATION_THRESHOLD;
        }
        
        private DateTime GetTokenExpTime(string accessToken)
        {
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(_credentials.AccessToken);
            return decodedToken.ValidTo;
        }

    }
}
