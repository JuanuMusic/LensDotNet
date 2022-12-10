namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetFollowModuleEIP712TypedData
    {
        public CreateSetFollowModuleEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateSetFollowModuleEIP712TypedDataValue Value { get; set; }
    }
}