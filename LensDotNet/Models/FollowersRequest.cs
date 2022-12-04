namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowersRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string ProfileId { get; set; }
    }
}