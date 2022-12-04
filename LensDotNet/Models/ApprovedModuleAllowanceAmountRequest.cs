namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ApprovedModuleAllowanceAmountRequest
    {
        public List<string> Currencies { get; set; }
        public List<CollectModules> CollectModules { get; set; }
        public List<string> UnknownCollectModules { get; set; }
        public List<FollowModules> FollowModules { get; set; }
        public List<string> UnknownFollowModules { get; set; }
        public List<ReferenceModules> ReferenceModules { get; set; }
        public List<string> UnknownReferenceModules { get; set; }
    }
}