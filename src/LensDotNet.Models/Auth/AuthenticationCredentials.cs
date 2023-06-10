using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Models.Auth
{
    public class AuthenticationCredentials
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
