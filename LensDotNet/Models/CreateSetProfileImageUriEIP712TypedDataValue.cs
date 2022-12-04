namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetProfileImageUriEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string ImageURI { get; set; }
    }
}