using LensDotNet.Client;

namespace LensDotNet.Tests.Client.Publication
{
    public class PublicationClient_Authenticated
    {
        [Test]
        public async Task Test_Report_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.Report(new ReportPublicationRequest
            {
                PublicationId = TestConfigs.EXISTING_PROFILE_ID,
                Reason = PublicationHelpers.BuildReportingReasonInputParams(PublicationReportReason.FAKE_ENGAGEMENT),
                AdditionalComments = "Test comment"
            }));
        }
    }
}
