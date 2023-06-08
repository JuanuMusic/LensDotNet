/// https://github.com/gabrielweyer/dotnet-decode-jwt/blob/f304f17b910e6233d1053a98bda3d8ada5e10d3e/src/dotnet-decode-jwt/JwtClaimsDecoder.cs

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace LendsDotnet.Client
{
    internal static class JwtClaimsDecoder
    {
        public static T GetClaims<T>(string jwt)
        {
            var base64UrlClaimsSet = GetBase64UrlClaimsSet(jwt);
            var claimsSet = DecodeBase64Url(base64UrlClaimsSet);

            return JsonSerializer.Deserialize<T>(claimsSet);
        }

        private static string GetBase64UrlClaimsSet(string jwt)
        {
            var firstDotIndex = jwt.IndexOf('.', StringComparison.Ordinal);
            var lastDotIndex = jwt.LastIndexOf('.');

            if (firstDotIndex == -1 || lastDotIndex <= firstDotIndex)
            {
                throw new FormatException("The JWT should contain two periods.");
            }

            return jwt.Substring(firstDotIndex + 1, lastDotIndex - firstDotIndex - 1);
        }

        private static string DecodeBase64Url(string base64Url)
        {
            var base64 = base64Url
                .Replace('-', '+')
                .Replace('_', '/')
                .PadRight(base64Url.Length + (4 - base64Url.Length % 4) % 4, '=');

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
