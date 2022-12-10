namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class EnabledModules
    {
        public List<EnabledModule> CollectModules { get; set; }
        public List<EnabledModule> FollowModules { get; set; }
        public List<EnabledModule> ReferenceModules { get; set; }
    }
}