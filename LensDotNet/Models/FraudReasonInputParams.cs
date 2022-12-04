namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FraudReasonInputParams
    {
        public PublicationReportingReason Reason { get; set; }
        public PublicationReportingFraudSubreason Subreason { get; set; }
    }
}