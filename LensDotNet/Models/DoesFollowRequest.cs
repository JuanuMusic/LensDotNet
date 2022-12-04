namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DoesFollowRequest
    {
        public List<DoesFollow> FollowInfos { get; set; }
    }
}