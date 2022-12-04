namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeeCollectModuleSettings
    {
        public CollectModules Type { get; set; }
        public string ContractAddress { get; set; }
        public ModuleFeeAmount Amount { get; set; }
        public string Recipient { get; set; }
        public float ReferralFee { get; set; }
        public bool FollowerOnly { get; set; }
    }
}