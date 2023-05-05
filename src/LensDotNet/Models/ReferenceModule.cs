namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ReferenceModule
    {
        public FollowOnlyReferenceModuleSettings FollowOnlyReferenceModuleSettings { get; set; }
        public UnknownReferenceModuleSettings UnknownReferenceModuleSettings { get; set; }
        public DegreesOfSeparationReferenceModuleSettings DegreesOfSeparationReferenceModuleSettings { get; set; }
    }
}