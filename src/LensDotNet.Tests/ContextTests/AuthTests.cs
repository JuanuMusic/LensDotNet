using System.Threading.Tasks;
using LensDotNet.Core.Extensions;
using LensDotNet.Models;
using LensDotNet.Tests.Utils;

namespace LensDotNet.Tests.ContextTests
{
	public class AuthTests : BaseContextTest
	{
		[Test]
		public async Task ShouldFetchChallenge()
		{
			var address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";

            
			var challenge = await Context.Challenge(new ChallengeRequest { Address = address })
				.AddField(c => c.Text)
                .AsExecutable(Context.QueryRunner)
                .Execute();

			Assert.That(challenge, Is.Not.Null);
            Assert.That(challenge.Result, Is.Not.Null);
            Assert.That(challenge.Result.Text, Is.Not.Empty);
			Assert.That(challenge.Result.Text, Does.Contain(address));
		}

        [Test]
        public async Task ShouldCorrectlyAuthenticateWithSignature()
        {
            var address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";

            var challenge = await Context.Challenge(new ChallengeRequest { Address = address })
                .AddField(c => c.Text)
                .AsExecutable(Context.QueryRunner)
                .Execute();

            string signature = Web3Helper.Sign(challenge.Result.Text);

            var auth = await Context.Authenticate(new SignedAuthChallenge { Address =address, Signature = signature })
                .AddField(r => r.AccessToken)
                .AddField(r => r.RefreshToken)
                .AsExecutable(Context.QueryRunner)
                .Execute();

            Assert.That(auth, Is.Not.Null);
            Assert.That(auth.Result, Is.Not.Null);
            Assert.That(auth.Result.RefreshToken, Is.Not.Null.And.Not.Empty);
            Assert.That(auth.Result.AccessToken, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ShouldCorrectlyRefreshAccessToken()
        {
            var address = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";

            var challenge = await Context.Challenge(new ChallengeRequest { Address = address })
                .AddField(c => c.Text)
                .AsExecutable(Context.QueryRunner)
                .Execute();

            string signature = Web3Helper.Sign(challenge.Result.Text);

            var auth = await Context.Authenticate(new SignedAuthChallenge { Address = address, Signature = signature })
                .AddField(r => r.AccessToken)
                .AddField(r => r.RefreshToken)
                .AsExecutable(Context.QueryRunner)
                .Execute();

            var refreshResp = await Context.Refresh(new RefreshRequest { RefreshToken = auth.Result.RefreshToken })
                .AddField(r => r.RefreshToken)
                .AddField(r => r.AccessToken)
                .AsExecutable(Context.QueryRunner)
                .Execute();

            Assert.That(refreshResp, Is.Not.Null);
            Assert.That(refreshResp.Result, Is.Not.Null);
            Assert.That(refreshResp.Result.RefreshToken, Is.Not.Null.And.Not.Empty);

            var verify = await Context.Verify(new VerifyRequest { AccessToken = refreshResp.Result.AccessToken })
                .Execute();
            Assert.That(verify.Result, Is.True);
        }
    }
}