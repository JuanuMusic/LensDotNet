namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateSetFollowModuleRequest
    {
        public string ProfileId { get; set; }
        public FollowModuleParams FollowModule { get; set; }
    }
}