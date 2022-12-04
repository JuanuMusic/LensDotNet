namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateCollectEIP712TypedData
    {
        public CreateCollectEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateCollectEIP712TypedDataValue Value { get; set; }
    }
}