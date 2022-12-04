using System;
using LensDotNet.Models;
using System.Threading.Tasks;

namespace LensDotNet.Tests
{
	public class FollowTests
	{
        [Test]
        public async Task CanFetchFollowers()
        {
            LensContext ctx = new LensContext();
            var profile = await ctx.Profile(new SingleProfileQueryRequest { Handle = "juanumusic.lens" })
                    .AddField(p => p.Name)
                    .AddField(p => p.Handle)
                    .AddField(p => p.Id)
                    .Execute();
            var resp = ctx.Followers(new FollowersRequest { ProfileId = profile.Id })
                    .AddField(p => p.Items, sub =>
                        sub.AddField(itm => itm.TotalAmountOfTimesFollowed))
                    .AddField(p => p.PageInfo, sub =>
                        sub.AddField(pi => pi.TotalCount).AddField(pi => pi.Next).AddField(pi => pi.Prev));
            
            Assert.That(resp, Is.Not.Null);
            var followers = await ((ContextQuery<PaginatedFollowersResult>)resp).Execute();
            Assert.That(followers.Items, Is.Not.Null);
            Assert.That(followers.Items.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task CanFetchFollowing()
        {
            LensContext ctx = new LensContext();
            var profile = await ctx.Profile(new SingleProfileQueryRequest { Handle = "juanumusic.lens" })
                    .AddField(p => p.Handle)
                    .AddField(p => p.OwnedBy)
                    .Execute();
            var resp = ctx.Following(new FollowingRequest { Address = profile.OwnedBy })
                    .AddField(p => p.Items, sub =>
                        sub.AddField(itm => itm.TotalAmountOfTimesFollowing))
                    .AddField(p => p.PageInfo, sub =>
                        sub.AddField(p => p.TotalCount));
            //var result = await _profiles.GetByHandle("juanumusic.lens");
            Assert.That(resp, Is.Not.Null);
            var followers = await resp.Execute();
            Assert.That(followers.Items, Is.Not.Null);
            Assert.That(followers.Items.Count, Is.GreaterThan(0));
        }
    }
}

