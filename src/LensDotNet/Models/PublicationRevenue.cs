namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationRevenue
    {
        public Publication Publication { get; set; }
        public RevenueAggregate Revenue { get; set; }
    }
}