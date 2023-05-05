namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MediaOutput
    {
        public string Item { get; set; }
        public string Type { get; set; }
        public string AltTag { get; set; }
        public string Cover { get; set; }
        public PublicationMediaSource Source { get; set; }
    }
}