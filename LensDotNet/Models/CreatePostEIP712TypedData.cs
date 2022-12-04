namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreatePostEIP712TypedData
    {
        public CreatePostEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreatePostEIP712TypedDataValue Value { get; set; }
    }
}