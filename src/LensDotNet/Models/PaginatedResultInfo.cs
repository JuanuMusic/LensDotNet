namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedResultInfo
    {
        public string Prev { get; set; }
        public string Next { get; set; }
        public int? TotalCount { get; set; }
    }
}