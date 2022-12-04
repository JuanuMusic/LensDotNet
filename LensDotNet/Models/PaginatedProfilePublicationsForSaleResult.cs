namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedProfilePublicationsForSaleResult
    {
        public List<PublicationForSale> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}