namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TransactionResult
    {
        public TransactionIndexedResult TransactionIndexedResult { get; set; }
        public TransactionError TransactionError { get; set; }
    }
}