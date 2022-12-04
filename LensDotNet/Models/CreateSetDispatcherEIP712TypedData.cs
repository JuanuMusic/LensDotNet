namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetDispatcherEIP712TypedData
    {
        public CreateSetDispatcherEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateSetDispatcherEIP712TypedDataValue Value { get; set; }
    }
}