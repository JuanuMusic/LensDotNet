namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReferenceModuleParams
    {
        public bool? FollowerOnlyReferenceModule { get; set; }
        public UnknownReferenceModuleParams UnknownReferenceModule { get; set; }
        public DegreesOfSeparationReferenceModuleParams DegreesOfSeparationReferenceModule { get; set; }
    }
}