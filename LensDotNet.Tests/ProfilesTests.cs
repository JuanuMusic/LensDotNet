using System;
using System.Linq;
using System.Threading.Tasks;
using LensDotNet.Models;
using LensDotNet.Services;

namespace LensDotNet.Tests
{
	public class ProfileTests
	{

		[Test]
		public async Task CanFetchProfileByHandle()
		{
			LensContext ctx = new LensContext();
			var resp = ctx.Profile(new SingleProfileQueryRequest { Handle = "juanumusic.lens" })
                .AddField(p => p.Handle);
			//var result = await _profiles.GetByHandle("juanumusic.lens");
			Assert.That(resp, Is.Not.Null);
			var profile = await resp.Execute();
			Assert.That(profile, Is.Not.Null);
			Assert.That(profile.Handle, Is.EqualTo("juanumusic.lens"));
		}

        [Test]
        public async Task CanFetchProfileByHandleWithAttributes()
        {
            LensContext ctx = new LensContext();
            var resp = ctx.Profile(new SingleProfileQueryRequest { Handle = "juanumusic.lens" })
                .AddField(p => p.Handle)
				.AddField(p => p.Attributes, sub => sub.AddField(atr => atr.DisplayType));
            //var result = await _profiles.GetByHandle("juanumusic.lens");
            Assert.That(resp, Is.Not.Null);
            var profile = await resp.Execute();
            Assert.That(profile, Is.Not.Null);
            Assert.That(profile.Handle, Is.EqualTo("juanumusic.lens"));
			Assert.That(profile.Attributes, Is.Not.Null);
            Assert.That(profile.Attributes.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task CanFetchMultipleProfiles()
        {
            LensContext ctx = new LensContext();
            var resp = ctx.Profiles(new ProfileQueryRequest { Handles = new System.Collections.Generic.List<string> { "juanumusic.lens", "stani.lens" } })
                    .AddField(ppr => ppr.Items, sub => sub.AddField(itm => itm.Handle))
                    .AddField(ppr => ppr.PageInfo, sub => sub.AddField(pi => pi.TotalCount));
            //var result = await _profiles.GetByHandle("juanumusic.lens");
            Assert.That(resp, Is.Not.Null);
            var profiles = await resp.Execute();
            Assert.That(profiles, Is.Not.Null);
            Assert.That(profiles.Items, Is.Not.Null);
            Assert.That(profiles.Items.Count, Is.EqualTo(2));
        }
    }
}

