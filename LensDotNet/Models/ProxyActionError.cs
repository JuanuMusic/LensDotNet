namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProxyActionError
    {
        public string Reason { get; set; }
        public string LastKnownTxId { get; set; }
    }
}