using LensDotNet.Client.Fragments.Publication;
using LensDotNet.Client.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LensDotNet.Client.Fragments.Gasless
{
    public record CreateSetDispatcherEIP712TypedDataTypesFragment
    {
        [JsonPropertyName("SetDispatcherWithSig")]
        public EIP712TypedDataField[] SetDispatcherWithSig { get;  set; }
    }
    public record EIP712TypedDataDomainFragment
    {
        public string Name { get; set; }
        public ChainId ChainId { get; set; }
        public string Version { get; set; }
        public ContractAddress VerifyingContract { get; set; }
    }

    public record CreateSetDispatcherEIP712TypedDataValueFragment
    {
        public Nonce Nonce { get; set; }
        public UnixTimestamp Deadline { get; set; }
        public ProfileId ProfileId { get; set; }
        public EthereumAddress Dispatcher { get; set; }

    }

    public record CreateSetDispatcherEIP712TypedDataFragment
    {
        public CreateSetDispatcherEIP712TypedDataTypesFragment Types { get; set; }
        public EIP712TypedDataDomainFragment Domain { get; set; }
        public CreateSetDispatcherEIP712TypedDataValueFragment Value { get; set; }
    }
    public record CreateSetDispatcherBroadcastItemResultFragment
    {
        public BroadcastId Id { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public CreateSetDispatcherEIP712TypedDataFragment TypedData { get; set; }
    }

    public record RelayResultFragment
    {
        public RelayerResultFragment? Result { get; set; }
        public RelayErrorFragment? Error { get; set; }
    }

    public record DispatcherFragment
    {
       public EthereumAddress Address { get; set; }
        public bool CanUseRelay { get; set; }
        public bool Sponsor { get; set; }
    }

    public record TransactionResultFragment
    {
        public TransactionIndexedResultFragment Result { get; set; }
        public TransactionErrorFragment Error { get; set; }
    }

    public record TransactionIndexedResultFragment
    {
        public bool Indexed { get; set; }
        public TxHash TxHash { get; set; }
        public TransactionReceiptFragment TxReceipt { get; set; }
        public PublicationMetadataStatusFragment MetadataStatus {get;set;}
    }

    public record TransactionReceiptFragment
    {
        public EthereumAddress? To { get; set; }
        public EthereumAddress From { get; set; }
        public ContractAddress? ContractAddress { get; set; }
        public int TransactionIndex { get; set; }
        public string? Root { get; set; }
        public string GasUsed { get; set; }
        public string LogsBloom { get; set; }
        public string BlockHash { get; set; }
        public TxHash TransactionHash { get; set; }
        public Log[] Logs { get; set; }
        public int BlockNumber { get; set; }
        public int Confirmations { get; set; }
        public string CumulativeGasUsed { get; set; }
        public string EffectiveGasPrice { get; set; }
        public bool Byzantium { get; set; }
        public int Type { get; set; }
        public int? Status { get; set; }
    }

    public record RelayerResultFragment
    {
        public TxHash TxHash { get; set; }
        public TxId TxId { get; set; }
    }

    public record RelayErrorFragment {
        public RelayErrorReasons Reason {get;set;}
    }

    public record TransactionErrorFragment
    {
        public TransactionErrorReasons Reason { get; set; }
    }
}
