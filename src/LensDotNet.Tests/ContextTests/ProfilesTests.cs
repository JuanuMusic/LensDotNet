using System;
using System.Linq;
using System.Threading.Tasks;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;
using NBitcoin.Secp256k1;
using Nethereum.Contracts.QueryHandlers.MultiCall;

namespace LensDotNet.Tests.ContextTests
{
    public class ProfileTests : BaseContextTest
    {

        [Test]
        public async Task CanFetchProfileByHandle()
        {
            var resp = await Context.Profile(new SingleProfileQueryRequest { Handle = "themanfromearth.test" })
                .AddField(p => p.Handle)
                .Execute(Context.QueryRunner);
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Handle, Is.EqualTo("themanfromearth.test"));
        }

        [Test]
        public async Task CanFetchProfileByHandleWithAttributes()
        {
            var resp = await Context.Profile(new SingleProfileQueryRequest { Handle = "themanfromearth.test" })
                .AddField(p => p.Handle)
                .AddField(p => p.Attributes, sub => sub.AddField(atr => atr.DisplayType))
                .Execute(Context.QueryRunner);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Handle, Is.EqualTo("themanfromearth.test"));
            Assert.That(resp.Result.Attributes, Is.Not.Null);
            //Assert.That(profile.Attributes.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task CanFetchProfilesOwnedBy()
        {
            var resp = await Context.Profiles(new ProfileQueryRequest { OwnedBy = new System.Collections.Generic.List<string> { "0x1c2eAdbB291709D3252610C431A6Ee355191E545" } })
                    .AddField(ppr => ppr.Items, sub => sub.AddField(itm => itm.Handle))
                    .AddField(ppr => ppr.PageInfo, sub => sub.AddField(pi => pi.TotalCount))
                    .Execute(Context.QueryRunner);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            Assert.That(resp.Result.Items.Count, Is.GreaterThan(0));
            Assert.That(resp.Result.Items[0].Handle, Is.EqualTo("themanfromearth.test"));
        }

        [Test]
        public async Task CanFetchMultipleProfiles()
        {
            var resp = await Context.Profiles(new ProfileQueryRequest { Handles = new System.Collections.Generic.List<string> { "themanfromearth.test" } })
                    .AddField(ppr => ppr.Items, sub => sub.AddField(itm => itm.Handle))
                    .AddField(ppr => ppr.PageInfo, sub => sub.AddField(pi => pi.TotalCount))
                    .Execute(Context.QueryRunner);


            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            Assert.That(resp.Result.Items.Count, Is.EqualTo(1));
        }
    }
}

