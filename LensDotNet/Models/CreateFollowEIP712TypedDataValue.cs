namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateFollowEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public List<string> ProfileIds { get; set; }
        public List<string> Datas { get; set; }
    }
}