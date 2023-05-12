using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Profile;
using ZeroQL;

namespace LensDotNet.Client.Fragments
{
    public static class FragmentBuildExtensions
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
    }
}
