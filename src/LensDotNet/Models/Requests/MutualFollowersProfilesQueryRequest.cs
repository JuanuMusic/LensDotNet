namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class MutualFollowersProfilesQueryRequest : BasePagingModel
    {
        public string ViewingProfileId { get; set; }
        public string YourProfileId { get; set; }
    }
}