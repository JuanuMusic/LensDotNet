
using LensDotNet.Client.Fragments.Gasless;
using Nethereum.ABI.EIP712;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nethereum.Web3.Accounts;

namespace LensDotNet.Tests.Utils
{
    public record TypeDataField(string Name, string Type);

    public static class Web3Helper
    {
        public static string Sign(string message, Account acc)
            => Sign(message, acc.PrivateKey);

        public static string Sign(string message, string privateKey)
        {
            EthereumMessageSigner signer = new EthereumMessageSigner();
            string signature = signer.EncodeUTF8AndSign(message, new EthECKey(privateKey));
            return signature;
        }

        public static string SignTypedData(EIP712TypedDataDomainFragment inputTypedData, string key)
        {
            Eip712TypedDataSigner signer = new Eip712TypedDataSigner();
            var ethECKey = new EthECKey(key);
            var typedData = new TypedData<EIP712TypedDataDomainFragment>
            {
                Domain = inputTypedData
            };
            //typedData.SetMessage(message);
            return signer.SignTypedDataV4(typedData, ethECKey);
        }

        public static string ValidateTypedDataSignature<TData>(TData data, TypedData<Domain> typedData, string signature, string privateKey)
        {
            var signer = new Eip712TypedDataSigner();

            return signer.RecoverFromSignatureV4(data, typedData, signature);
            //var ethECKey = new EthECKey(privateKey);
            //return addressRecovered;
        }

    }
}

