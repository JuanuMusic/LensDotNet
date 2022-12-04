namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedFollowingResult
    {
        public List<Following> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}