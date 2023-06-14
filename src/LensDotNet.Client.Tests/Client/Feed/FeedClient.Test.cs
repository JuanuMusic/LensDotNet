using LensDotNet.Client;
using LensDotNet.Client.Feed;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests.Client.Feed
{
    public class FeedClientTest
    {
        private readonly static Account _account = new Account(TestConfigs.TEST_PK);
        FeedClient client;
        AuthenticationClient authenticatedClient;

        [SetUp]
        public async Task Setup()
        {
            authenticatedClient = await Helpers.GetAuthenticatedClient(_account);
            client = new FeedClient(TestConfigs.DEV_CONFIG, authenticatedClient);
        }

        [Test]
        public async Task Test_FetchWithRequestObject_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () => await client.Fetch(new FeedRequest{ ProfileId = TestConfigs.EXISTING_PROFILE_ID }));

        [Test]
        public async Task Test_FetchWithProfileId_Should_Run_Succesfully()
            => Assert.DoesNotThrowAsync(async () => await client.Fetch(TestConfigs.EXISTING_PROFILE_ID));

    }
}
