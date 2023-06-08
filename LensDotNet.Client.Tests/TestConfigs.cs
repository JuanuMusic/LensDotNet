using LensDotNet.Client;
using LensDotNet.Config;
using LensDotNet.Tests.Utils;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests
{
    internal static class TestConfigs
    {
        public readonly static LensConfig DEV_CONFIG = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);

        public static string TEST_PK = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";
        public static string EXISTING_PUBLICATION_ID = "0x01aa-0x16";
        public static string EXISTING_PROFILE_ID = "0x8530";
        public static string ALT_PROFILE_ID = "0x0186";
        public readonly static Account TEST_WEB3_ACCOUNT = new Account(TEST_PK);

        public static Handle PROFILE_HANDLE = "lensdotnet";
    }
}
