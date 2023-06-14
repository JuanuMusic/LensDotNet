using LensDotNet.Client;
using LensDotNet.Client.Authentication;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Tests.Utils;
using Nethereum.ABI.EIP712;
using Nethereum.Contracts;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Tests
{
    public static class Helpers
    {

        public static async Task<AuthenticationClient> GetAuthenticatedClient(Account account)
        {
            var authenticationClient = new AuthenticationClient(TestConfigs.DEV_CONFIG);
            var challenge = await authenticationClient.GenerateChallenge(account.Address);
            var signature = Web3Helper.Sign(challenge.Text, account);
            await authenticationClient.Authenticate(account.Address, signature);
            return authenticationClient;
        }
    }
}