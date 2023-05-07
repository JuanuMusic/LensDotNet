using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Profile.GQL
{
    public static class ProfileQueries
    {
        private static string? _profile;
        public static string? Profile
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_profile))
                    _profile = Queries.GetQueryFromResource("LensDotNet.Client.Profile.GQL.profile.gql");
                return _profile;
            }
        }
    }
}
