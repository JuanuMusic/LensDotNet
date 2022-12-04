namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ClaimHandleRequest
    {
        public string Id { get; set; }
        public string FreeTextHandle { get; set; }
        public FollowModuleParams FollowModule { get; set; }
    }
}