namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ElectedMirror
    {
        public string MirrorId { get; set; }
        public Profile Profile { get; set; }
        public string Timestamp { get; set; }
    }
}