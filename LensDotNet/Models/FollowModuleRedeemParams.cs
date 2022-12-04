namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowModuleRedeemParams
    {
        public FeeFollowModuleRedeemParams FeeFollowModule { get; set; }
        public ProfileFollowModuleRedeemParams ProfileFollowModule { get; set; }
        public UnknownFollowModuleRedeemParams UnknownFollowModule { get; set; }
    }
}