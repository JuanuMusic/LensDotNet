using LensDotNet.Authentication;
using LensDotNet.Client.Authentication.Adapters;
using LensDotNet.Config;
using LensDotNet.Tests.Utils;
using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client.Authentication
{
    public class AuthenticationTest
    {
        private readonly static Account _account = new Account(Web3Helper.TEST_PK);

        [Test]
        public async Task ChallengeShouldReturnChallengeForAddress()
        {
            var authApi = new AuthenticationClient(TestConfigs.DEV_CONFIG);
            var challenge = await authApi.GenerateChallenge(_account.Address);
            Assert.IsNotNull(challenge);
            Assert.That(challenge.Text.Contains("Sign in with ethereum to lens"));
        }

        [Test]
        public async Task TestIsAuthenticatedReturnsFalseWhenNoCredentials()
        {
            var authApi = new AuthenticationClient(TestConfigs.DEV_CONFIG);
            Assert.IsFalse(await authApi.IsAuthenticated());
        }

        [Test]
        public async Task TestIsAuthenticatedReturnsFalseWhenCredentialsExpiredAndCantRefresh()
        {
            Assert.Pass("TODO: Implement mocks to test.");
        }

        [Test]
        public async Task TestIsAuthenticatedShouldReturnTrueWithValidCredentials()
        {
            var authApi = new AuthenticationClient(TestConfigs.DEV_CONFIG);
            var challenge = await authApi.GenerateChallenge(_account.Address);
            var signed = Web3Helper.Sign(challenge.Text, _account);
            await authApi.Authenticate(_account.Address, signed);
            Assert.IsTrue(await authApi.IsAuthenticated());
        }
    }
}
