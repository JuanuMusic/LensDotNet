namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeedItemRoot
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}