namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class GenerateModuleCurrencyApprovalDataRequest
    {
        public string Currency { get; set; }
        public string Value { get; set; }
        public CollectModules CollectModule { get; set; }
        public string UnknownCollectModule { get; set; }
        public FollowModules FollowModule { get; set; }
        public string UnknownFollowModule { get; set; }
        public ReferenceModules ReferenceModule { get; set; }
        public string UnknownReferenceModule { get; set; }
    }
}