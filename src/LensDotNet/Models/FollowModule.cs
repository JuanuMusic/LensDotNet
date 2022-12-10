namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FollowModule
    {
        public FeeFollowModuleSettings FeeFollowModuleSettings { get; set; }
        public ProfileFollowModuleSettings ProfileFollowModuleSettings { get; set; }
        public RevertFollowModuleSettings RevertFollowModuleSettings { get; set; }
        public UnknownFollowModuleSettings UnknownFollowModuleSettings { get; set; }
    }
}