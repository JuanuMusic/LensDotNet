namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CollectModuleParams
    {
        public FreeCollectModuleParams FreeCollectModule { get; set; }
        public bool? RevertCollectModule { get; set; }
        public FeeCollectModuleParams FeeCollectModule { get; set; }
        public LimitedFeeCollectModuleParams LimitedFeeCollectModule { get; set; }
        public LimitedTimedFeeCollectModuleParams LimitedTimedFeeCollectModule { get; set; }
        public TimedFeeCollectModuleParams TimedFeeCollectModule { get; set; }
        public UnknownCollectModuleParams UnknownCollectModule { get; set; }
    }
}