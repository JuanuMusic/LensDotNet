namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateMirrorEIP712TypedData
    {
        public CreateMirrorEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateMirrorEIP712TypedDataValue Value { get; set; }
    }
}