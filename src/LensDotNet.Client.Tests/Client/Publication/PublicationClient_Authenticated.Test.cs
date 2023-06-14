using LensDotNet.Client;
using LensDotNet.Client.Authentication;
using LensDotNet.IPFS;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;
using System.Text;
using System.Text.Json;
using System.Timers;

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
            authenticatedClient = await Helpers.GetAuthenticatedClient(_account);
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
        public async Task Test_CreatePostViaDispatcher_Should_GenerateTx()
        {
            var fetchResp = await new ProfileClient(TestConfigs.DEV_CONFIG, authenticatedClient).Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID });
            if (fetchResp.Dispatcher == null)
                throw new Exception("Dispatcher not set");

            var httpClient = new HttpClient();
            var ipfsClient = new IPFSClient(new Uri(TestConfigs.IPFS_API_ENDPOINT), TestConfigs.IPFS_USERNAME, TestConfigs.IPFS_PASSWORD);
            
            var imageBytes = File.ReadAllBytes("./ContentFiles/lensdotnetlogo.png");            
            var addImageResult = await ipfsClient.Add(imageBytes, "lensdotnetlogo.png");

            PublicationMetadataV2Input metadata = new PublicationMetadataV2Input
            {
                Name = "LensDotNet",
                Version = "2.0.0",
                Metadata_id = "lens_dot_net_0",
                Locale = "en-US",
                MainContentFocus = PublicationMainFocus.TextOnly,
                Description = "A test post from LensDotNet",
                Attributes = { },
                Content = "LensDotNet - the .NET cross-platform SDK for the Lens Protocol API. Compatible with: Unity, ~~Xamarin~~ MAUI, and all .NET standard compatible frameworks.",
                Image = $"ipfs://{addImageResult.Hash}"
            };
            var json = JsonSerializer.Serialize(metadata,ZeroQL.Json.ZeroQLJsonOptions.Options);
            var file = await ipfsClient.Add(Encoding.UTF8.GetBytes(json), "lensdotnet_metadata.json");
            
            var resp = await client.CreatePostViaDispatcher(new CreatePublicPostRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID,
                ContentURI = $"ipfs://{file.Hash}",
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
            // give it a few secs to index
            await Task.Delay(5000);

            var indexedResp = await new TransactionClient(TestConfigs.DEV_CONFIG, authenticatedClient).HasTxHashBeenIndexed(resp.Result.TxHash);
            Assert.That(indexedResp, Is.Not.Null);
            Assert.That(indexedResp.Result, Is.Not.Null);
            Assert.That(indexedResp.Result.MetadataStatus, Is.Not.Null);
            var pendingOrSuccess = indexedResp.Result.MetadataStatus.Status == PublicationMetadataStatusType.Pending || indexedResp.Result.MetadataStatus.Status == PublicationMetadataStatusType.Success;
            Assert.That(pendingOrSuccess);
            if(indexedResp.Result.MetadataStatus.Status == PublicationMetadataStatusType.MetadataValidationFailed)
            {
                throw new Exception($"Metadata validation failed: {indexedResp.Result.MetadataStatus.Reason}");
            }
        }

        [Test]
        public async Task Test_MetadataStatus_Should_Run_Succesfully()
        {
            var client = new PublicationClient(TestConfigs.DEV_CONFIG);
            var createPostResp = await new PublicationClient(TestConfigs.DEV_CONFIG, authenticatedClient).CreatePostViaDispatcher(new CreatePublicPostRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID,
                ContentURI = "ipfs://QmduywkKCwpJM66pTTPDWATZ8vgUmSW9HPPjVdryJv8Du2",
                CollectModule = new CollectModuleParams
                {
                    FreeCollectModule = new FreeCollectModuleParams
                    {
                        FollowerOnly = true
                    }
                },
                ReferenceModule = new ReferenceModuleParams
                {
                    FollowerOnlyReferenceModule = true
                }
            });

            //do
            //{
            //    var idxResp = await txClient.HasTxHashBeenIndexed(createPostResp.Result.TxId);
            //    indexed = idxResp.Result.Indexed;
            //    System.Threading.Thread.Sleep(1000);
            //} while (!indexed);

            var resp = await client.MetadataStatus(createPostResp.Result.TxId);
            Assert.That(resp, Is.Not.Null);
        }
    }
}
