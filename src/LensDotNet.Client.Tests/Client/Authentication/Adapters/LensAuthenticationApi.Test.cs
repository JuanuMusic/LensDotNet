using LensDotNet.Client.Authentication.Adapters;
using LensDotNet.Config;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Client.Authentication.Adapters
{
    public class LensAuthenticationApiTests
    {
        LensAuthenticationApi _api;
        Account _account;

        [SetUp]
        public void SetUp()
        {
            _api = new LensAuthenticationApi(new Uri(LensConfig.DEVELOPMENT_GQL_ENDPOINT));
            _account = new Account(TestConfigs.TEST_PK);
        }

        [Test]
        public async Task TestGetChallenge()
        {
            var challenge = await _api.Challenge(_account.Address);
            Assert.IsNotNull(challenge);
            Assert.IsNotEmpty(challenge.Text);
        }

        [Test]
        public async Task TestAuthorizationSuccessful()
        {
            var challenge = await _api.Challenge(_account.Address);
            Assert.IsNotNull(challenge);
            var signature = Web3Helper.Sign(challenge.Text, _account.PrivateKey);
            var credentials = await _api.Authenticate(_account.Address, signature);
            Assert.IsNotNull(credentials);
            var isValid = await _api.Verify(credentials.AccessToken);
            Assert.IsTrue(isValid);
        }

        [Test]
        public async Task TestRefreshSuccessful()
        {
            var challenge = await _api.Challenge(_account.Address);
            Assert.IsNotNull(challenge);
            var signature = Web3Helper.Sign(challenge.Text, _account.PrivateKey);
            var credentials = await _api.Authenticate(_account.Address, signature);
            Assert.IsNotNull(credentials);
            var newCredentials = await _api.Refresh(credentials.RefreshToken);
            Assert.IsNotNull(newCredentials);
            var isValid = await _api.Verify(newCredentials.AccessToken);
            Assert.IsTrue(isValid);

        }

        [Test]
        public async Task TestVerifyInvalid()
        {
            var isValid = await _api.Verify("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjB4YjE5QzI4OTBjZjk0N0FEM2YwYjdkN0U1QTlmZkJjZTM2ZDNmOWJkMiIsInJvbGUiOiJub3JtYWwiLCJpYXQiOjE2NDUxMDQyMzEsImV4cCI6MTY0NTEwNjAzMX0.lwLlo3UBxjNGn5D_W25oh2rg2I_ZS3KVuU9n7dctGIU");
            Assert.IsFalse(isValid);
        }
    }
}
