using System.Net;
using System.Threading.Tasks;
using LensDotNet.Services.Auth;
using LensDotNet.Tests;
using LensDotNet.Tests.Utils;

namespace LensDotNet.Tests
{
    public class AutenticatorServiceTests : BaseContextTest
    {

        AuthenticationService _authenticationService;
        const string ADDRESS = "0x1c2eAdbB291709D3252610C431A6Ee355191E545";
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _authenticationService = new AuthenticationService(Context, ADDRESS);
        }

        [Test]
        public async Task ShouldFetchChallenge()
        {
            var challengeRequest = await _authenticationService.GetChallenge();
            Assert.That(challengeRequest, Is.Not.Null.And.Not.Empty);
            Assert.That(challengeRequest, Does.Contain(ADDRESS));
        }

        [Test]
        public async Task ShouldCorrectlyAuthenticateWithSignature()
        {
            var challengeRequest = await _authenticationService.GetChallenge();
            string signature = Web3Helper.Sign(challengeRequest);
            var credentials = await _authenticationService.Authenticate(signature);
            Assert.That(credentials, Is.Not.Null);
            Assert.That(credentials.RefreshToken, Is.Not.Null.And.Not.Empty);
            Assert.That(credentials.AccessToken, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task ShouldCorrectlyInitializeWithExistingCredentials()
        {
            var challengeRequest = await _authenticationService.GetChallenge();
            string signature = Web3Helper.Sign(challengeRequest);
            var credentials = await _authenticationService.Authenticate(signature);

            var newAuthService = new AuthenticationService(Context, ADDRESS,credentials);
            bool isValid = await newAuthService.Verify();
            Assert.That(isValid, Is.True);
        }

        [Test]
        public async Task ShouldCorrectlyRefreshAccessToken()
        {
            var challengeRequest = await _authenticationService.GetChallenge();
            string signature = Web3Helper.Sign(challengeRequest);
            var creds = await _authenticationService.Authenticate(signature);
            var newCredentials = await _authenticationService.Refresh();
            Assert.That(newCredentials, Is.Not.Null);
            Assert.That(newCredentials.RefreshToken, Is.Not.Null.And.Not.Empty);
            Assert.That(newCredentials.AccessToken, Is.Not.Null.And.Not.Empty);

            var verify = await _authenticationService.Verify();
            Assert.That(verify, Is.True);
        }
    }
}