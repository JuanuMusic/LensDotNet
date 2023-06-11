using LensDotNet.Client;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client
{
    public class LensClientTest
    {
        LensClient client;
        [SetUp] public void SetUp() {
            client = new LensClient(TestConfigs.DEV_CONFIG);
        }

        [Test]
        public void Test_AllClients_Are_Accessible()
        {
            Assert.That(client.Authentication, Is.Not.Null);
            Assert.That(client.Explore, Is.Not.Null);
            Assert.That(client.Gasless, Is.Not.Null);
            Assert.That(client.Profile, Is.Not.Null);
            Assert.That(client.Publication, Is.Not.Null);
        }

        [Test]
        public async Task Test_Client_Authenticates()
        {
            Account account = new Account(TestConfigs.TEST_PK);
            var challenge = await client.Authentication.GenerateChallenge(account.Address);
            var signature = Web3Helper.Sign(challenge.Text, account);
            await client.Authentication.Authenticate(account.Address, signature);
            Assert.That(await client.Authentication.IsAuthenticated());
        }
    }
}
