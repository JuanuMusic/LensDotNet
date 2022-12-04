namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class InternalPublicationsFilterRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Source { get; set; }
        public string Secret { get; set; }
    }
}