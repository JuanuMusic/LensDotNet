namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeeFollowModuleSettings
    {
        public FollowModules Type { get; set; }
        public string ContractAddress { get; set; }
        public ModuleFeeAmount Amount { get; set; }
        public string Recipient { get; set; }
    }
}