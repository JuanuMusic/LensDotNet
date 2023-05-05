namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PublicMediaRequest
    {
        public string ItemCid { get; set; }
        public string Type { get; set; }
        public string AltTag { get; set; }
        public string Cover { get; set; }
    }
}