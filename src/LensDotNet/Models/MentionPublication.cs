namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MentionPublication
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}