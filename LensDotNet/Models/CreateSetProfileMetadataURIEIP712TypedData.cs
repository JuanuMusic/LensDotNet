namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileMetadataURIEIP712TypedData
    {
        public CreateSetProfileMetadataURIEIP712TypedDataTypes Types { get; set; }
        public EIP712TypedDataDomain Domain { get; set; }
        public CreateSetProfileMetadataURIEIP712TypedDataValue Value { get; set; }
    }
}