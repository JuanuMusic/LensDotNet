namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReportingReasonInputParams
    {
        public SensitiveReasonInputParams SensitiveReason { get; set; }
        public IllegalReasonInputParams IllegalReason { get; set; }
        public FraudReasonInputParams FraudReason { get; set; }
        public SpamReasonInputParams SpamReason { get; set; }
    }
}