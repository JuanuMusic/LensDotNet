namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Follow
    {
        public string Profile { get; set; }
        public FollowModuleRedeemParams FollowModule { get; set; }
    }
}