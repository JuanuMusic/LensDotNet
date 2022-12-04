namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SpamReasonInputParams
    {
        public PublicationReportingReason Reason { get; set; }
        public PublicationReportingSpamSubreason Subreason { get; set; }
    }
}