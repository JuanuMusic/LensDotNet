namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SetDefaultProfileEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string Wallet { get; set; }
        public string ProfileId { get; set; }
    }
}