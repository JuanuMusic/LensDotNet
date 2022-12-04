namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class DegreesOfSeparationReferenceModuleParams
    {
        public bool CommentsRestricted { get; set; }
        public bool MirrorsRestricted { get; set; }
        public int DegreesOfSeparation { get; set; }
    }
}