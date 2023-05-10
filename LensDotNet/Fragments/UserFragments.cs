using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroQL;

namespace LensDotNet.Client.Fragments
{
    public static class UserFragments
    {
        [GraphQLFragment]
        public static ProfileFragment AsProfileFragment(this Profile profile)
        {
            return new ProfileFragment
            {
                Id = profile.Id,
                Bio = profile.Bio,
                Handle = profile.Handle,
                Interests = profile.Interests,
                IsDefault = profile.IsDefault,
                Name = profile.Name,
                OwnedBy = profile.OwnedBy
            };
        }
    }
}
