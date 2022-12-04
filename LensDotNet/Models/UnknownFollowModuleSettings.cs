namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UnknownFollowModuleSettings
    {
        public FollowModules Type { get; set; }
        public string ContractAddress { get; set; }
        public string FollowModuleReturnData { get; set; }
    }
}