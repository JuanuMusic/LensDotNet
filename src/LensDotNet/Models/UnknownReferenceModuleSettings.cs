namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class UnknownReferenceModuleSettings
    {
        public ReferenceModules Type { get; set; }
        public string ContractAddress { get; set; }
        public string ReferenceModuleReturnData { get; set; }
    }
}