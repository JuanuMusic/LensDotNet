namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationQueryRequest
    {
        public string PublicationId { get; set; }
        public string TxHash { get; set; }
    }
}