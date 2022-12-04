namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicMediaResults
    {
        public string SignedUrl { get; set; }
        public MediaOutput Media { get; set; }
    }
}