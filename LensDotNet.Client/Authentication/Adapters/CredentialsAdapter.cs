using LendsDotnet.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
            var expirationTime = _credentials.AccessToken.GetTokenExpTime();
            return now >= expirationTime - TOKEN_EXPIRATION_THRESHOLD;
        }

        internal bool CanRefresh()
        {
            var now = DateTime.UtcNow;
            var expirationTime = _credentials.AccessToken.GetTokenExpTime();
            return now < expirationTime - TOKEN_EXPIRATION_THRESHOLD;
        }
    }

    public static class StringExtensions
    {
        public static T JSONDeserialize<T>(this string jsonString)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

        public static DateTime GetTokenExpTime(this Jwt accessToken)
        {
            var claims = JwtClaimsDecoder.GetClaims<LensJWT>(accessToken);
            return claims.ExpiresAt;
        }
    }

    public class LensJWT
    {
        [JsonProperty("iat")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime IssuedAt { get; set; }

        [JsonProperty("exp")]
        [Newtonsoft.Json.JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    //public class SecondEpochConverter : DateTimeConverterBase
    //{
    //    private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.Value == null) { return null; }
    //        return _epoch.AddMilliseconds((long)reader.Value / 1000d);
    //    }
    //}
}
