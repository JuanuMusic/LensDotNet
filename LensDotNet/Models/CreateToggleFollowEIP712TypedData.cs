namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateToggleFollowEIP712TypedData
    {
        public CreateToggleFollowEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateToggleFollowEIP712TypedDataValue Value { get; set; }
    }
}