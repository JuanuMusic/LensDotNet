
using LensDotNet.Client;
using LensDotNet.Client.Fragments.Gasless;
using LensDotNet.Client.Json.Converters;
using NBitcoin;
using Nethereum.ABI.EIP712;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using System.Text.Json;
using ZeroQL;

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

        public static string SignTypedData<T>(T inputTypedData, string key)
        {
            Eip712TypedDataSigner signer = new Eip712TypedDataSigner();
            var ethECKey = new EthECKey(key);
            
            //typedData.SetMessage(message);
            var opts = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            opts.Converters.Add(new ZeroQLScalarJsonConverter<Nonce>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ChainId>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<UnixTimestamp>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ProfileId>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<EthereumAddress>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ContractAddress>());
            var json = System.Text.Json.JsonSerializer.Serialize(inputTypedData, opts);
            return signer.SignTypedDataV4<Domain>(json,ethECKey, "value");
        }

        public static string ValidateTypedDataSignature<T>(T data, string signature)
        {
            //typedData.SetMessage(message);
            var opts = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            opts.Converters.Add(new ZeroQLScalarJsonConverter<Nonce>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ChainId>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<UnixTimestamp>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ProfileId>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<EthereumAddress>());
            opts.Converters.Add(new ZeroQLScalarJsonConverter<ContractAddress>());

            Eip712TypedDataSigner signer = new Eip712TypedDataSigner();

            var json = System.Text.Json.JsonSerializer.Serialize(data, opts);
            return signer.RecoverFromSignatureV4(json, signature, "value");
            //var ethECKey = new EthECKey(privateKey);
            //return addressRecovered;
        }
    }
}

