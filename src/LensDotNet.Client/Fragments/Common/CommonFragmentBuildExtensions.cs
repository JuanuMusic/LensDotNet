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
            => new CommonPaginatedResultInfo
            {
                Next = resultInfo.Next,
                Prev = resultInfo.Prev
            };

        [GraphQLFragment]
        public static WalletFragment AsFragment(this Wallet wallet)
            => new WalletFragment { 
                Address = wallet.Address, 
                DefaultProfile = wallet.DefaultProfile(p => p.AsFragment())
            };

        [GraphQLFragment]
        public static PaginatedResult<WalletFragment> AsPaginatedResult(this PaginatedWhoCollectedResult resultInfo)
            => new PaginatedResult<WalletFragment>
            {
                PageInfo = resultInfo.PageInfo(pi => pi.AsCommonPaginatedResultInfo()),
                Items = resultInfo.Items(itm => itm.AsFragment())
            };
    }
}
