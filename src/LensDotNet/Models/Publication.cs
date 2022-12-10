namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Publication
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
        public Mirror Mirror { get; set; }
    }
}