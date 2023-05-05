using System;
using Nethereum.JsonRpc.Client;
using System.Threading.Tasks;
using LensDotNet.Tests.Utils;

namespace LensDotNet.Tests
{
    public class LensClientTests : BaseLensClientTests
    {
        [Test]
        public async Task ShouldCorrectlyAuthenticate()
        {
            await Client.Authenticate(Account.Address, (challenge) => Web3Helper.Sign(challenge));
            Assert.That(await Client.IsAuthenticated(Account.Address), Is.True);
        }
    }
}

