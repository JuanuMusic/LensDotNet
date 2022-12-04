namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SensitiveReasonInputParams
    {
        public PublicationReportingReason Reason { get; set; }
        public PublicationReportingSensitiveSubreason Subreason { get; set; }
    }
}