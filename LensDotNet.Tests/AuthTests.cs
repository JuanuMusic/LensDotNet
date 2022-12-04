using System;
using System.Threading.Tasks;
using LensDotNet.Models;

namespace LensDotNet.Tests
{
	public class AuthTests
	{
		[Test]
		public async Task ShouldFetchChallenge()
		{
			var address = "0x2ad91063e489CC4009DF7feE45C25c8BE684Cf6a";

            LensContext ctx = new LensContext();
			var challengeRequest = ctx.Challenge(new ChallengeRequest { Address = address })
				.AddField(c => c.Text);
			var challenge = await challengeRequest.Execute();

			Assert.That(challenge, Is.Not.Null);
			Assert.That(challenge.Text, Is.Not.Empty);
			Assert.That(challenge.Text, Does.Contain(address));
		}
	}
}