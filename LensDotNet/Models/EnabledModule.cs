namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class EnabledModule
    {
        public string ModuleName { get; set; }
        public string ContractAddress { get; set; }
        public List<ModuleInfo> InputParams { get; set; }
        public List<ModuleInfo> RedeemParams { get; set; }
        public List<ModuleInfo> ReturnDataParms { get; set; }
    }
}