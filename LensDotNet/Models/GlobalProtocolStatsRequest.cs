namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class GlobalProtocolStatsRequest
    {
        public string FromTimestamp { get; set; }
        public string ToTimestamp { get; set; }
        public List<string> Sources { get; set; }
    }
}