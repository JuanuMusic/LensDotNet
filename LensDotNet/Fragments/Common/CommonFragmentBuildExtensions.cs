using LensDotNet.Client.Fragments.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroQL;

namespace LensDotNet.Client.Fragments.Common
{
    public static class CommonFragmentBuildExtensions
    {
        [GraphQLFragment]
        public static CommonPaginatedResultInfo AsCommonPaginatedResultInfo(this PaginatedResultInfo resultInfo)
        {
            return new CommonPaginatedResultInfo
            {
                Next = resultInfo.Next,
                Prev = resultInfo.Prev
            };
        }

        [GraphQLFragment]
        public static WalletFragment AsFragment(this Wallet wallet)
            => new WalletFragment { 
                Address = wallet.Address, 
                DefaultProfile = wallet.DefaultProfile(p => p.AsProfileFragment())
            };
    }
}
