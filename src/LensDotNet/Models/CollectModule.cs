namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CollectModule
    {
        public FreeCollectModuleSettings FreeCollectModuleSettings { get; set; }
        public FeeCollectModuleSettings FeeCollectModuleSettings { get; set; }
        public LimitedFeeCollectModuleSettings LimitedFeeCollectModuleSettings { get; set; }
        public LimitedTimedFeeCollectModuleSettings LimitedTimedFeeCollectModuleSettings { get; set; }
        public RevertCollectModuleSettings RevertCollectModuleSettings { get; set; }
        public TimedFeeCollectModuleSettings TimedFeeCollectModuleSettings { get; set; }
        public UnknownCollectModuleSettings UnknownCollectModuleSettings { get; set; }
    }
}