namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReportPublicationRequest
    {
        public string PublicationId { get; set; }
        public ReportingReasonInputParams Reason { get; set; }
        public string AdditionalComments { get; set; }
    }
}