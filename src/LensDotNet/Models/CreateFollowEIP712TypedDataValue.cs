namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Nethereum.ABI.FunctionEncoding.Attributes;

    [Struct("FollowWithSig")]
    public partial class CreateFollowEIP712TypedDataValue
    {
        [Parameter("uint256", "nonce", 1)]
        public BigInteger Nonce { get; set; }
        [Parameter("uint256", "deadline", 1)]
        public BigInteger Deadline { get; set; }
        [Parameter("string[]", "profileIds", 1)]
        public List<string> ProfileIds { get; set; }
        [Parameter("string[]", "datas", 1)]
        public List<string> Datas { get; set; }
    }
}