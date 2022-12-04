namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MirrorEvent
    {
        public Profile Profile { get; set; }
        public string Timestamp { get; set; }
    }
}