using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Config;
using LensDotNet.Fragments.Feed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Feed
{
    public class FeedClient : BaseClient
    {
        public FeedClient(LensConfig config, AuthenticationClient? authentication = null) : base(config, authentication)
        {
        }

        public async Task<PaginatedResult<FeedItemFragment>> Fetch(ProfileId profileId)
            => await Fetch(new FeedRequest { ProfileId = profileId });

        public async Task<PaginatedResult<FeedItemFragment>> Fetch(FeedRequest request)
        {
            var resp = await _client.Query(new { Input = request }, 
                static (i, o) => o.Feed(i.Input, output => output.AsPaginatedResult()));
            resp.AssertErrors();
            return resp.Data;
        }
    }
}
