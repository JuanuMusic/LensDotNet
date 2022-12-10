namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using LensDotNet.Models.Modules;

    public partial class Follow<TFollowModuleParam>: Follow where TFollowModuleParam : IModuleParams
    {
        public TFollowModuleParam FollowModule { get; set; }
    }

    public partial class Follow
    {
        public string Profile { get; set; }
    }
}