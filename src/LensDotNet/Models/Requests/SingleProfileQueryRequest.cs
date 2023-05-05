namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SingleProfileQueryRequest
    {
        public string? ProfileId { get; set; }
        public string? Handle { get; set; }
    }
}