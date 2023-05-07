
using Nethereum.ABI.EIP712;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Utils
{
    public record TypeDataField(string Name, string Type);

    public static class Web3Helper
    {
        public const string TEST_PK = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";

        public static string Sign(string message, Account acc)
            => Sign(message, acc.PrivateKey);

        public static string Sign(string message, string privateKey = TEST_PK)
        {
            EthereumMessageSigner signer = new EthereumMessageSigner();
            string signature = signer.EncodeUTF8AndSign(message, new EthECKey(privateKey));
            return signature;
        }

        public static string SignTypedData<T>(T data, TypedData<Domain> typedData, string key = TEST_PK)
        {
            Eip712TypedDataSigner signer = new Eip712TypedDataSigner();
            var ethECKey = new EthECKey(key);
            return signer.SignTypedDataV4(data, typedData, ethECKey);
        }

        public static string ValidateTypedDataSignature<TData>(TData data, TypedData<Domain> typedData, string signature, string privateKey = TEST_PK)
        {
            var signer = new Eip712TypedDataSigner();

            return signer.RecoverFromSignatureV4(data, typedData, signature);
            //var ethECKey = new EthECKey(privateKey);
            //return addressRecovered;
        }

    }
}

