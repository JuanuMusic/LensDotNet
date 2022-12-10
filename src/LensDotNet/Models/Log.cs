namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Log
    {
        public int BlockNumber { get; set; }
        public string BlockHash { get; set; }
        public int TransactionIndex { get; set; }
        public bool Removed { get; set; }
        public string Address { get; set; }
        public string Data { get; set; }
        public List<string> Topics { get; set; }
        public string TransactionHash { get; set; }
        public int LogIndex { get; set; }
    }
}