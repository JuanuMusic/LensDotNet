namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class LimitedFeeCollectModuleParams
    {
        public string CollectLimit { get; set; }
        public ModuleFeeAmountParams Amount { get; set; }
        public string Recipient { get; set; }
        public float ReferralFee { get; set; }
        public bool FollowerOnly { get; set; }
    }
}