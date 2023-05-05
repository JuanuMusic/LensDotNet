namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileImageUriEIP712TypedData
    {
        public CreateSetProfileImageUriEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateSetProfileImageUriEIP712TypedDataValue Value { get; set; }
    }
}