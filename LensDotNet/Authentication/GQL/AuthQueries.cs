using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Authentication 
{
    public static class AuthQueries
    {
        private static string? _authenticate;
        public static string? Authenticate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_authenticate))
                    _authenticate = Queries.GetQueryFromResource("LensDotNet.Client.Authentication.GQL.authenticate.gql");
                return _authenticate;
            }
        }

        private static string? _challenge;
        public static string? Challenge
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_challenge))
                    _challenge = Queries.GetQueryFromResource("LensDotNet.Client.Authentication.GQL.challenge.gql");
                return _challenge;
            }
        }

        private static string? _verify;
        public static string? Verify
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_verify))
                    _verify = Queries.GetQueryFromResource("LensDotNet.Client.Authentication.GQL.verify.gql");
                return _verify;
            }
        }

        private static string? _refresh;
        public static string? Refresh {
            get
            {
                if (string.IsNullOrWhiteSpace(_refresh))
                    _refresh = Queries.GetQueryFromResource("LensDotNet.Client.Authentication.GQL.refresh.gql");
                return _refresh;
            }
        }
    }
}
