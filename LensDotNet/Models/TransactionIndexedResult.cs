namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TransactionIndexedResult
    {
        public bool Indexed { get; set; }
        public string TxHash { get; set; }
        public TransactionReceipt TxReceipt { get; set; }
        public PublicationMetadataStatus MetadataStatus { get; set; }
    }
}