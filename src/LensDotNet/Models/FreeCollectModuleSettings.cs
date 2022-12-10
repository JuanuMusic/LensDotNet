namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class FreeCollectModuleSettings
    {
        public CollectModules Type { get; set; }
        public string ContractAddress { get; set; }
        public bool FollowerOnly { get; set; }
    }
}