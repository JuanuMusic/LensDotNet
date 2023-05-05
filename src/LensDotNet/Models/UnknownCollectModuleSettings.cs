namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UnknownCollectModuleSettings
    {
        public CollectModules Type { get; set; }
        public string ContractAddress { get; set; }
        public string CollectModuleReturnData { get; set; }
    }
}