namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class WhoCollectedPublicationRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string PublicationId { get; set; }
    }
}