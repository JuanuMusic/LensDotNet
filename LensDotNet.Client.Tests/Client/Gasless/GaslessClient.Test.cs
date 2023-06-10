using LensDotNet.Client;
using LensDotNet.Tests.Utils;
using NBitcoin.OpenAsset;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Client.Gasless
{
    public class GaslessClient_Tests
    {
        private readonly static Account _account = new Account(TestConfigs.TEST_PK);
        GaslessClient client;
        AuthenticationClient authenticatedClient;

        [SetUp]
        public async Task Setup()
        {
            authenticatedClient = await Helpers.GetAuthenticationClient(_account);
            client = new GaslessClient(TestConfigs.DEV_CONFIG, authenticatedClient);
        }


        [Test]
        public async Task Test_SetDispatcher_Should_Set_Dispatcher()
        {
            var resp = await client.CreateSetDispatcherTypedData(new SetDispatcherRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID
            });

            string signed = Web3Helper.SignTypedData(resp.TypedData, _account.PrivateKey);
            Assert.IsNotEmpty(signed);
            // TODO: Uncomment when Nethereum PR is merged: https://github.com/Nethereum/Nethereum/pull/952
            //string signer = Web3Helper.ValidateTypedDataSignature(resp.TypedData, signed);
            //Assert.That(signer, Is.EqualTo(_account.Address));
            var txClient = new TransactionClient(TestConfigs.DEV_CONFIG, authenticatedClient);
            var broadcastResp= await txClient.Broadcast(new BroadcastRequest { Id = resp.Id, Signature = signed });
            Assert.IsNotNull(broadcastResp);
            Assert.IsNull(broadcastResp.Error);
            Assert.IsNotNull(broadcastResp.Result);
            Assert.IsNotNull(broadcastResp.Result.TxId);
        }

        [Test]
        public async Task Test_HasTxHashBeenIndexed_Should_Run_Succesfully_Using_TxHash()
        {
            var fetchResp = await new ProfileClient(TestConfigs.DEV_CONFIG, authenticatedClient).Fetch(new SingleProfileQueryRequest { ProfileId = TestConfigs.EXISTING_PROFILE_ID });
            if (fetchResp.Dispatcher == null)
                throw new Exception("Dispatcher not set");

            var createPostResp = await new PublicationClient(TestConfigs.DEV_CONFIG, authenticatedClient).CreatePostViaDispatcher(new CreatePublicPostRequest
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
            var resp = await client.HasTxBeenIndexed(createPostResp.Result.TxHash);
            Assert.IsNotNull(resp);
        }
    }
}
