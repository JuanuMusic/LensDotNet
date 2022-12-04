namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PaginatedPublicationResult
    {
        public List<Publication> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }
}