namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileMetadataURIEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string Metadata { get; set; }
    }
}