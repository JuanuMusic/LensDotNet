namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateFollowEIP712TypedData
    {
        public CreateFollowEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateFollowEIP712TypedDataValue Value { get; set; }
    }
}