namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using LensDotNet.Models.Modules;

    public partial class FollowModuleRedeemParams : IModuleParams
    {
        public FeeFollowModuleRedeemParams FeeFollowModule { get; set; }
        public ProfileFollowModuleRedeemParams ProfileFollowModule { get; set; }
        public UnknownFollowModuleRedeemParams UnknownFollowModule { get; set; }
    }
}