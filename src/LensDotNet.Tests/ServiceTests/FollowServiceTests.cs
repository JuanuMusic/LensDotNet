using System;
using System.Threading.Tasks;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;
using LensDotNet.Services.Auth;
using LensDotNet.Services.Follow;
using NBitcoin.Secp256k1;

namespace LensDotNet.Tests.ServiceTests
{
	public class FollowServiceTests : BaseContextTest
	{
        FollowService _followService;
        Credentials _credentials;
        string address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";
        string pk = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";
        string testHandle = "themanfromearth.test";
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            AuthenticationService auth = new AuthenticationService(Context, address);
            _credentials = auth.Authorize((challenge) => Utils.Web3Helper.Sign(challenge, pk)).Result;
            _followService = new FollowService(Context);
        }

        [Test]
        public async Task ShouldSuccessfullyFollowProfile()
        {
            // Get the profile ID
            string toFollow = "microgreen1012.test";
            var viewingProfile = await Context.Profile(new SingleProfileQueryRequest { Handle = toFollow })
                    .AddField(p => p.Id)
                    .Execute(Context.QueryRunner);
            // Follow it
            await _followService.Follow(viewingProfile.Result.Id);

            // Get my id
            var myProfile = await Context.Profile(new SingleProfileQueryRequest { Handle = testHandle })
                    .AddField(p => p.Id)
                    .Execute(Context.QueryRunner);

            // Chck if Im following
            var doesFollow = await _followService.MutualProfileFollows(viewingProfile.Result.Id, myProfile.Result.Id);
            Assert.That(doesFollow, Is.Not.False);
        }
    }
}

