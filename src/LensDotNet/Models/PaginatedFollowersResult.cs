namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedFollowersResult
    {
        public List<Follower> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}