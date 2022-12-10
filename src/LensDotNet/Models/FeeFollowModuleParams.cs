namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FeeFollowModuleParams
    {
        public ModuleFeeAmountParams Amount { get; set; }
        public string Recipient { get; set; }
    }
}