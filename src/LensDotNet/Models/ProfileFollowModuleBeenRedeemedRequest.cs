namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ProfileFollowModuleBeenRedeemedRequest
    {
        public string FollowProfileId { get; set; }
        public string RedeemingProfileId { get; set; }
    }
}