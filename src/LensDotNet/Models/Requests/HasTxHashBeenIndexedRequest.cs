namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class HasTxHashBeenIndexedRequest
    {
        public string TxHash { get; set; }
        public string TxId { get; set; }
    }
}