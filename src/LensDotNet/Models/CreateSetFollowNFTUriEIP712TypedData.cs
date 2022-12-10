namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetFollowNFTUriEIP712TypedData
    {
        public CreateSetFollowNFTUriEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateSetFollowNFTUriEIP712TypedDataValue Value { get; set; }
    }
}