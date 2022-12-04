namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class WhoReactedPublicationRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string PublicationId { get; set; }
    }
}