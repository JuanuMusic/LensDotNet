﻿using LensDotNet.Client.Json.Converters;
using System;
using System.Collections.Generic;
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
        public RelayerResult? Result { get; set; }
        public RelayError? Error { get; set; }
    }

    public record DispatcherFragment
    {
       public EthereumAddress Address { get; set; }
        public bool CanUseRelay { get; set; }
        public bool Sponsor { get; set; }
    }
}
