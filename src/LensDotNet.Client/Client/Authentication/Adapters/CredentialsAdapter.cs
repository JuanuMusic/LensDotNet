using LensDotnet.Client;
using LensDotNet.Client.Json.Converters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LensDotNet.Client.Authentication.Adapters
{
    public class CredentialsAdapter
    {

        public readonly static TimeSpan TOKEN_EXPIRATION_THRESHOLD = TimeSpan.FromSeconds(30);
        
        private AuthenticationResult _credentials;
        public string RefreshToken { get => _credentials == null ? String.Empty : _credentials.RefreshToken; }
        public string AccessToken { get => _credentials == null ? String.Empty : _credentials.AccessToken; }
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
            => JsonSerializer.Deserialize<T>(jsonString);

        public static DateTime GetTokenExpTime(this Jwt accessToken)
        {
            var claims = JwtClaimsDecoder.GetClaims<LensJWT>(accessToken);
            return claims.ExpiresAt;
        }
    }

    public class LensJWT
    {
        [JsonPropertyName("iat")]
        [JsonConverter(typeof(UnixTimestampToDateTimeConverter))]
        public DateTime IssuedAt { get; set; }

        [JsonPropertyName("exp")]
        [JsonConverter(typeof(UnixTimestampToDateTimeConverter))]
        public DateTime ExpiresAt { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("role")]
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
