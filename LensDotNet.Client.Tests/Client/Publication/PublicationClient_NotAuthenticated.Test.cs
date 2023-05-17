using LensDotNet.Client;
using Org.BouncyCastle.Asn1.Cms;
using System.Xml.Linq;

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
            Assert.That(resp.Post, Is.Not.Null);
            Assert.That(resp.Post.Id.Value, Is.EqualTo(TestConfigs.EXISTING_PUBLICATION_ID));
        }

        [Test]
        public async Task Test_FetchAll_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.FetchAll(new PublicationsQueryRequest { PublicationIds = new InternalPublicationId[] { TestConfigs.EXISTING_PUBLICATION_ID } }));
        }

        [Test]
        public async Task Test_AllWalletsWhoCollected_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.AllWalletsWhoCollected(new WhoCollectedPublicationRequest { PublicationId = TestConfigs.EXISTING_PUBLICATION_ID }));
        }

        [Test]
        public async Task Test_ValidateMetadata_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            var result =  await client.ValidateMetadata(new PublicationMetadataV2Input { 
                Name= "Test",
                  Attributes = new MetadataAttributeInput[] { },
                  Content= "Test",
                  Locale = "en",
                  MainContentFocus = PublicationMainFocus.TextOnly,
                  Metadata_id = "1",
                  Version = "2.0.0", });

            Assert.IsTrue(result.Valid);
        }

        [Test]
        public async Task Test_AllForSale_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.AllForSale(new ProfilePublicationsForSaleRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID }));
        }

        [Test]
        public async Task Test_MetadataStatus_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            Assert.DoesNotThrowAsync(async () => await client.MetadataStatus(new GetPublicationMetadataStatusRequest { PublicationId = TestConfigs.EXISTING_PUBLICATION_ID}));
        }
    }
}
