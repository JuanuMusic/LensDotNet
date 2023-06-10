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
        public async Task Test_Sign_SetDispatcherData_Should_Generate_Correct_Signature()
        {
            var resp = await client.CreateSetDispatcherTypedData(new SetDispatcherRequest
            {
                ProfileId = TestConfigs.EXISTING_PROFILE_ID
            });

            string signed = Web3Helper.SignTypedData(resp.TypedData, _account.PrivateKey);

            string decoded = Web3Helper.ValidateTypedDataSignature(resp.TypedData, signed);
            Assert.That(decoded, Is.EqualTo(_account.Address));
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
            string signer = Web3Helper.ValidateTypedDataSignature(resp.TypedData, signed);
            Assert.That(signer, Is.EqualTo(_account.Address));
            var txClient = new TransactionClient(TestConfigs.DEV_CONFIG, authenticatedClient);
            var broadcastResp= await txClient.Broadcast(new BroadcastRequest { Id = resp.Id, Signature = signed });
            Assert.IsNotNull(broadcastResp);
            Assert.IsNull(broadcastResp.Error);
            Assert.IsNotNull(broadcastResp.Result);
            Assert.IsNotNull(broadcastResp.Result.TxId);
        }
    }
}
