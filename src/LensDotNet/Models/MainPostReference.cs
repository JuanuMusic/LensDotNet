namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MainPostReference
    {
        public Post Post { get; set; }
        public Mirror Mirror { get; set; }
    }
}