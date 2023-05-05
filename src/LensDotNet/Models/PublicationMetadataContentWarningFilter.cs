namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationMetadataContentWarningFilter
    {
        public List<PublicationContentWarning> IncludeOneOf { get; set; }
    }
}