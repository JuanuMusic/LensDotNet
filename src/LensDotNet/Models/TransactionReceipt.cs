namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TransactionReceipt
    {
        public string To { get; set; }
        public string From { get; set; }
        public string ContractAddress { get; set; }
        public int TransactionIndex { get; set; }
        public string Root { get; set; }
        public string GasUsed { get; set; }
        public string LogsBloom { get; set; }
        public string BlockHash { get; set; }
        public string TransactionHash { get; set; }
        public List<Log> Logs { get; set; }
        public int BlockNumber { get; set; }
        public int Confirmations { get; set; }
        public string CumulativeGasUsed { get; set; }
        public string EffectiveGasPrice { get; set; }
        public bool Byzantium { get; set; }
        public int Type { get; set; }
        public int? Status { get; set; }
    }
}