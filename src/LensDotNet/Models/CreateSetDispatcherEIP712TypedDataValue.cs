namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetDispatcherEIP712TypedDataValue
    {
        public string Nonce { get; set; }
        public string Deadline { get; set; }
        public string ProfileId { get; set; }
        public string Dispatcher { get; set; }
    }
}