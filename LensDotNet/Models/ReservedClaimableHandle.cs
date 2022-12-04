namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReservedClaimableHandle
    {
        public string Id { get; set; }
        public string Handle { get; set; }
        public string Source { get; set; }
        public string Expiry { get; set; }
    }
}