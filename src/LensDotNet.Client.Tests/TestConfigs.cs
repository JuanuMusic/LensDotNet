using LensDotNet.Client;
using LensDotNet.Config;
using LensDotNet.Tests.Utils;
using Microsoft.Extensions.Configuration;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3.Accounts;


namespace LensDotNet.Tests
{
    public class IPFSSettings
    {
        public string User { get; set; }
        public string Password { get; set; }    
    }
    internal static class TestConfigs
    {
        public readonly static LensConfig DEV_CONFIG = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);

        public static string TEST_PK = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";
        public static string EXISTING_PUBLICATION_ID = "0x01aa-0x16";
        public static string EXISTING_PROFILE_ID = "0x852c";
        public static string ALT_PROFILE_ID = "0x0186";
        public readonly static Account TEST_WEB3_ACCOUNT = new Account(TEST_PK);

        public static Handle PROFILE_HANDLE = "lensdotnet";
        public static IConfiguration Configuration { get; set; }

        public static string IPFS_USERNAME => Configuration.GetSection("ipfs")["user"];
        public static string IPFS_PASSWORD => Configuration.GetSection("ipfs")["password"];
        public static string IPFS_API_ENDPOINT => Configuration.GetSection("ipfs")["api_endpoint"];
        static TestConfigs()
        {
            var bldr = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true);
            Configuration = bldr.Build();
        }
    }
}
