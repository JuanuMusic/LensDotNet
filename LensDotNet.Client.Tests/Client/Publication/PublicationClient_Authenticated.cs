using LensDotNet.Client;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Client.Publication
{
    public class PublicationClient_Authenticated
    {
        private readonly static Account _account = new Account(Web3Helper.TEST_PK);
        [Test]
        public async Task Test_Report_Should_Run_Succesfully()
        {
            var authenticatedClient = await Helpers.GetAuthenticatedClient(_account);
            var client = new PublicationClient(TestConfigs.DEV_CONFIG, authenticatedClient);
            Assert.DoesNotThrowAsync(async () => await client.Report(new ReportPublicationRequest
            {
                PublicationId = TestConfigs.EXISTING_PROFILE_ID,
                Reason = PublicationHelpers.BuildReportingReasonInputParams(PublicationReportReason.FAKE_ENGAGEMENT),
                AdditionalComments = "Test comment"
            }));
        }
    }
}
