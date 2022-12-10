using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Nethereum.ABI.EIP712;
using Newtonsoft.Json;
using LensDotNet.Tests.Utils;
using Newtonsoft.Json.Serialization;
using LensDotNet.Models;
using LensDotNet.Models.Requests;
using LensDotNet.Core.Extensions;

namespace LensDotNet.Tests.ContextTests
{
    public class FollowTests : BaseContextTest
    {
        [Test]
        public async Task CanFetchFollowers()
        {
            var profile = await Context.Profile(new SingleProfileQueryRequest { Handle = "themanfromearth.test" })
                    .AddField(p => p.Name)
                    .AddField(p => p.Handle)
                    .AddField(p => p.Id)
                    .Execute(Context.QueryRunner);

            var resp = await Context.Followers(new FollowersRequest { ProfileId = profile.Result.Id })
                    .AddField(p => p.Items, sub =>
                        sub.AddField(itm => itm.TotalAmountOfTimesFollowed))
                    .AddField(p => p.PageInfo, sub =>
                        sub.AddField(pi => pi.TotalCount).AddField(pi => pi.Next).AddField(pi => pi.Prev))
                    .Execute(Context.QueryRunner);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            //Assert.That(followers.Items.Count, Is.GreaterThan());
        }

        [Test]
        public async Task CanFetchFollowing()
        {
            var profile = await Context.Profile(new SingleProfileQueryRequest { Handle = "themanfromearth.test" })
                    .AddField(p => p.Handle)
                    .AddField(p => p.OwnedBy)
                    .Execute(Context.QueryRunner);
            var resp = await Context.Following(new FollowingRequest { Address = profile.Result.OwnedBy })
                    .AddField(p => p.Items, sub =>
                        sub.AddField(itm => itm.TotalAmountOfTimesFollowing))
                    .AddField(p => p.PageInfo, sub =>
                        sub.AddField(p => p.TotalCount))
                    .Execute(Context.QueryRunner);
            //var result = await _profiles.GetByHandle("juanumusic.lens");
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Items, Is.Not.Null);
            //Assert.That(followers.Items.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task CanFollow()
        {
            // AUTHENTICATIE
            var address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";

            var challenge = await Context.Challenge(new ChallengeRequest { Address = address })
                .AddField(c => c.Text)
                .Execute(Context.QueryRunner);

            string signature = Utils.Web3Helper.Sign(challenge.Result.Text);

            var auth = await Context.Authenticate(new SignedAuthChallenge { Address = address, Signature = signature })
                .AddField(r => r.AccessToken).AddField(r => r.RefreshToken)
                .Execute(Context.QueryRunner);

            Context.QueryRunner.SetJWTAuthToken(auth.Result.AccessToken);

            string toFollow = "microgreen1012.test";
            var profile = await Context.Profile(new SingleProfileQueryRequest { Handle = toFollow })
                    .AddField(p => p.Id)
                    .Execute(Context.QueryRunner);

            // Check we are validated
            var verify = await Context.Verify(new VerifyRequest { AccessToken = auth.Result.AccessToken })
                .Execute();
            Assert.That(verify.Result, Is.True);

            // Create typed data for follow
            var resp = await Context.CreateFollowTypedData(new FollowRequest { Follow = new List<Follow> { new Follow { Profile = profile.Result.Id } } })
                    .AddField(r => r.Id)
                    .AddField(r => r.TypedData,
                        sub => sub.AddField(td => td.Types,
                            typesQuery => typesQuery.AddField(t => t.FollowWithSig,
                                followingQuery => followingQuery
                                    .AddField(f => f.Name)
                                    .AddField(f => f.Type)))
                            .AddField(td => td.Value,
                                valueQuery => valueQuery
                                    .AddField(v => v.Nonce)
                                    .AddField(v => v.Deadline)
                                    .AddField(v => v.ProfileIds)
                                    .AddField(v => v.Datas))
                            .AddField(td => td.Domain,
                            sub1 => sub1
                                .AddField(d => d.Name)
                                .AddField(d => d.ChainId)
                                .AddField(d => d.VerifyingContract)
                                .AddField(d => d.Version)
                                ))
                    .Execute(Context.QueryRunner);

            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Result, Is.Not.Null);
            Assert.That(resp.Result.Id, Is.Not.Null);
            Assert.That(resp.Result.TypedData, Is.Not.Null);
            Assert.That(resp.Result.TypedData.Domain, Is.Not.Null);
            Assert.That(resp.Result.TypedData.Domain.Name, Is.Not.Null);
            Assert.That(resp.Result.TypedData.Domain.ChainId, Is.Not.Null);

            // Convert to Nethereum model
            var mappedTypedData = AutomapperBuilder.Mapper.Map<TypedData<Domain>>(resp.Result.TypedData);
            // Sign the data
            string signedTypedData = Web3Helper.SignTypedData(resp.Result.TypedData.Value, mappedTypedData);
            string recoveredAddress = Web3Helper.ValidateTypedDataSignature(resp.Result.TypedData.Value, mappedTypedData, signedTypedData);
            Assert.That(recoveredAddress, Is.EqualTo(address));
            var signerProfile = await Context.Profile(new SingleProfileQueryRequest { Handle = "themanfromearth.test" })
                    .AddField(p => p.Id)
                    .AddField(p => p.OwnedBy)
                    .Execute(Context.QueryRunner);

            string json1 = JsonConvert.SerializeObject(mappedTypedData);
            string json2 = JsonConvert.SerializeObject(resp.Result.TypedData.Value);

            var broadcastResp = await Context.Broadcast(new BroadcastRequest { Id = resp.Result.Id, Signature = signedTypedData })
                    .AddPossibleType<RelayerResult>(relayerQuery => relayerQuery
                        .AddField(r => r.TxHash)
                        .AddField(r => r.TxId))
                    .AddPossibleType<RelayError>(relayerError => relayerError
                        .AddField(e => e.Reason))
                    .Execute(Context.QueryRunner);


            Assert.That(broadcastResp, Is.Not.Null);
            Assert.That(broadcastResp.Result, Is.Not.Null);
            Assert.That(broadcastResp.Result.Reason, Is.Null);


            var followers = await Context.Followers(new FollowersRequest { ProfileId = profile.Result.Id })
                    .AddField(p => p.Items, sub =>
                        sub.AddField(itm => itm.TotalAmountOfTimesFollowed))
                    .AddField(p => p.PageInfo, sub =>
                        sub.AddField(pi => pi.TotalCount).AddField(pi => pi.Next).AddField(pi => pi.Prev))
                    .Execute(Context.QueryRunner);

            Assert.That(followers, Is.Not.Null);
            Assert.That(followers.Result, Is.Not.Null);
            Assert.That(followers.Result.Items, Is.Not.Null);
            //Assert.That(followers.Items.Count, Is.GreaterThan(0));
        }
    }
}

