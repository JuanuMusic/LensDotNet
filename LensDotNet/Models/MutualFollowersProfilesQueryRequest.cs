namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MutualFollowersProfilesQueryRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string ViewingProfileId { get; set; }
        public string YourProfileId { get; set; }
    }
}