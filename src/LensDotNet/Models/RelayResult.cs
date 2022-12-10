namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public class RelayResult
    {
        public RelayErrorReasons? Reason { get; set; }

        public string? TxHash { get; set; }
        public string? TxId { get; set; }
    }
}