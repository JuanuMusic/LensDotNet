using System;
namespace LensDotNet.Services.Auth
{
    public record Credentials(string AccessToken, string RefreshToken);
}

