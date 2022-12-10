namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using Nethereum.ABI.FunctionEncoding.Attributes;

    public partial class CreateFollowEIP712TypedData
    {
        public CreateFollowEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateFollowEIP712TypedDataValue Value { get; set; }
    }
}