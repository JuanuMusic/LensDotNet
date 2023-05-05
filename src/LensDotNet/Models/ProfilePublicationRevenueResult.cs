namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfilePublicationRevenueResult
    {
        public List<PublicationRevenue> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}