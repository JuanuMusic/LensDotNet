namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DegreesOfSeparationReferenceModuleSettings
    {
        public ReferenceModules Type { get; set; }
        public string ContractAddress { get; set; }
        public bool CommentsRestricted { get; set; }
        public bool MirrorsRestricted { get; set; }
        public int DegreesOfSeparation { get; set; }
    }
}