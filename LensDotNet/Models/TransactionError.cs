namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TransactionError
    {
        public TransactionErrorReasons Reason { get; set; }
        public TransactionReceipt TxReceipt { get; set; }
    }
}