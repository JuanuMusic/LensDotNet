using LensDotNet.Authentication;
using LensDotNet.Client;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Tests.Utils;
using Nethereum.ABI.EIP712;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ProfileId = TestConfigs.EXISTING_PROFILE_ID,
                Enable = true
            });

            string signed = Web3Helper.SignTypedData(resp.TypedData.Domain, _account.PrivateKey);
            Assert.IsNotEmpty(signed);
        }
    }
}
