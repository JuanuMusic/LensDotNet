namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SetDefaultProfileEIP712TypedData
    {
        public SetDefaultProfileEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public SetDefaultProfileEIP712TypedDataValue Value { get; set; }
    }
}