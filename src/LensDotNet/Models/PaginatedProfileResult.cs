namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedProfileResult
    {
        public List<Profile> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}