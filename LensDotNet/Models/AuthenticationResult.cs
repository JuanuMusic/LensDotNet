namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AuthenticationResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}