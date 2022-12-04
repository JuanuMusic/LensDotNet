namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RevertCollectModuleSettings
    {
        public CollectModules Type { get; set; }
        public string ContractAddress { get; set; }
    }
}