namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class IllegalReasonInputParams
    {
        public PublicationReportingReason Reason { get; set; }
        public PublicationReportingIllegalSubreason Subreason { get; set; }
    }
}