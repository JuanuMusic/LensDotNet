namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RevertFollowModuleSettings
    {
        public FollowModules Type { get; set; }
        public string ContractAddress { get; set; }
    }
}