
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using NBitcoin;
using Nethereum.ABI.EIP712;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.HdWallet;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LensDotNet.Tests.Utils
{
    public record TypeDataField(string Name, string Type);

    public static class Web3Helper
    {
        public const string TEST_PK = "184e2728ff5f73adeea760dfb34a096072dc6354b31d87e9f76cf9f4d523f146";

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

        public static string ValidateTypedDataSignature<TData>(TData data, TypedData<Domain>  typedData, string signature, string privateKey = TEST_PK)
        {
            var signer = new Eip712TypedDataSigner();
            
            return signer.RecoverFromSignatureV4(data, typedData, signature);
            //var ethECKey = new EthECKey(privateKey);
            //return addressRecovered;
        }

    }
}

