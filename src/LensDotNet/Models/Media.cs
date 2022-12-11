namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public partial class Media : DynamicObject
    {
        public string Url { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Size { get; set; }
        public string MimeType { get; set; }
        public string AltTag { get; set; }
        public string Cover { get; set; }
    }
}