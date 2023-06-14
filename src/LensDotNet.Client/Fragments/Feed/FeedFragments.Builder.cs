using LensDotNet.Client;
using LensDotNet.Client.Fragments.Common;
using LensDotNet.Client.Fragments.Publication;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ZeroQL;

namespace LensDotNet.Fragments.Feed
{
    public static class PublicationFragmentsBuildExtensions
    {
        [GraphQLFragment]
        public static PaginatedResult<FeedItemFragment> AsPaginatedResult(this PaginatedFeedResult result)
            => new PaginatedResult<FeedItemFragment>
            {
                Items = result.Items(i => i.AsFragment()),
                PageInfo = result.PageInfo(pi => pi.AsCommonPaginatedResultInfo())
            };

        [GraphQLFragment]
        public static FeedItemFragment AsFragment(this FeedItem item)
            => new FeedItemFragment
            {
                RootPost = item.Root(r => r.On<Post>().Select(p => ((Post)p).AsFragment())),
                RootComment = item.Root(r => r.On<Comment>().Select(c => ((Comment)c).AsFragment())),
                Comments = item.Comments(c => ((Comment)c).AsFragment()),
                Collects = item.Collects(c => c.AsFragment()),
                ElectedMirror = item.ElectedMirror(m => m.AsFragment()),
                Mirrors = item.Mirrors(m => m.AsFragment()),
                Reactions = item.Reactions(r => r.AsFragment())
            };
    }
}
