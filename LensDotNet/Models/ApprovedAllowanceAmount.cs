namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ApprovedAllowanceAmount
    {
        public string Currency { get; set; }
        public string Module { get; set; }
        public string ContractAddress { get; set; }
        public string Allowance { get; set; }
    }
}