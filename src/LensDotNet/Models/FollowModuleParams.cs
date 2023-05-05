namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowModuleParams
    {
        public FeeFollowModuleParams FeeFollowModule { get; set; }
        public bool? ProfileFollowModule { get; set; }
        public bool? RevertFollowModule { get; set; }
        public bool? FreeFollowModule { get; set; }
        public UnknownFollowModuleParams UnknownFollowModule { get; set; }
    }
}