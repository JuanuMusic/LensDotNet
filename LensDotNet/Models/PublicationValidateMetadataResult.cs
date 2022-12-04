namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicationValidateMetadataResult
    {
        public bool Valid { get; set; }
        public string Reason { get; set; }
    }
}