namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedWhoReactedResult
    {
        public List<WhoReactedResult> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}