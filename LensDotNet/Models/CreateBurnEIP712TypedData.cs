namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateBurnEIP712TypedData
    {
        public CreateBurnEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateBurnEIP712TypedDataValue Value { get; set; }
    }
}