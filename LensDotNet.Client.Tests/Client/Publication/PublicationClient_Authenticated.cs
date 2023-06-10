using LensDotNet.Client;
using LensDotNet.Client.Authentication;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Client.Publication
{
    public class PublicationClient_Authenticated
    {
        private readonly static Account _account = new Account(TestConfigs.TEST_PK);
        PublicationClient client;
        AuthenticationClient authenticatedClient;

        [SetUp]
        public async Task Setup()
        {
            authenticatedClient = await Helpers.GetAuthenticationClient(_account);
            client = new PublicationClient(TestConfigs.DEV_CONFIG, authenticatedClient);
        }
        
        [Test]
        public async Task Test_Report_Should_Run_Succesfully()
        {
            Assert.DoesNotThrowAsync(async () => await client.Report(new ReportPublicationRequest
            {
                PublicationId = TestConfigs.EXISTING_PROFILE_ID,
                Reason = PublicationHelpers.BuildReportingReasonInputParams(PublicationReportReason.FAKE_ENGAGEMENT),
                AdditionalComments = "Test comment"
            }));
        }

        [Test]
        public async Task Test_CreatePostViaDispatcher_Should_Run_Succesfully()
        {
            var fetchResp = await new ProfileClient(TestConfigs.DEV_CONFIG, authenticatedClient).Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID });
            if (fetchResp.Dispatcher == null)
                throw new Exception("Dispatcher not set");

            var resp = await client.CreatePostViaDispatcher(new CreatePublicPostRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID,
                ContentURI = "ipfs://QmduywkKCwpJM66pTTPDWATZ8vgUmSW9HPPjVdryJv8Du2",
                CollectModule = new CollectModuleParams
                {
                    FreeCollectModule = new FreeCollectModuleParams
                    {
                        FollowerOnly = false
                    }
                },
                ReferenceModule = new ReferenceModuleParams
                {
                    FollowerOnlyReferenceModule = true
                }
            });

            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.Result);
            Assert.IsNotNull(resp.Result.TxId);
        }
    }
}
