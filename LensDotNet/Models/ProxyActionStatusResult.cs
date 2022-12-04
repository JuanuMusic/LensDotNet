namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProxyActionStatusResult
    {
        public string TxHash { get; set; }
        public string TxId { get; set; }
        public ProxyActionStatusTypes Status { get; set; }
    }
}