using LensDotNet.Client;
namespace LensDotNet.Tests.Client.Publication
{
    public class PublicationClient_NotAuthenticated
    {
        [Test]
        public async Task Test_Fetch_Should_Return_Requested_Publication()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            var resp = await client.Fetch(new PublicationQueryRequest { PublicationId = TestConfigs.EXISTING_PUBLICATION_ID });
            Assert.That(resp, Is.Not.Null);
            Assert.That(resp.Id == TestConfigs.EXISTING_PUBLICATION_ID);
        }
    }
}
