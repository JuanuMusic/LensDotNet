namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NFTsResult
    {
        public List<NFT> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}