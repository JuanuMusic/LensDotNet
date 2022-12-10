namespace LensDotNet.Models.Requests
{
    using System;
    using System.Collections.Generic;
    using LensDotNet.Models.Modules;

    public partial class FollowRequest<TFollowModuleParams> where TFollowModuleParams : IModuleParams
    {
        public List<Follow<TFollowModuleParams>> Follow { get; set; } = new List<Follow<TFollowModuleParams>>();
    }

    public partial class FollowRequest 
    {
        public List<Follow> Follow { get; set; } = new List<Follow>();
    }
}