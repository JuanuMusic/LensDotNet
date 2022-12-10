namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateBurnEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string TokenId { get; set; }
    }
}