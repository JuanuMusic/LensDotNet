namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowingRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string Address { get; set; }
    }
}