namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateCommentEIP712TypedData
    {
        public CreateCommentEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateCommentEIP712TypedDataValue Value { get; set; }
    }
}