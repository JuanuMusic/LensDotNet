namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DoesFollowResponse
    {
        public string FollowerAddress { get; set; }
        public string ProfileId { get; set; }
        public bool Follows { get; set; }
        public bool IsFinalisedOnChain { get; set; }
    }
}