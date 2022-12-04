namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedWhoCollectedResult
    {
        public List<Wallet> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}